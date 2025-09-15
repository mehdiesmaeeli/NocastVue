using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NoCast.App.Common.Dtos;
using NoCast.App.Common.Exception;
using NoCast.App.Common.Statics;
using NoCast.App.Contract.Services;
using NoCast.App.Data;
using NoCast.App.Dtos;
using NoCast.App.Migrations;
using NoCast.App.Models;

namespace NoCast.App.Services
{
    public class ApplicationTaskService : IApplicationTaskService
    {
        protected readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        protected readonly IMapper _mapper;
        public ApplicationTaskService(ApplicationDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<ServiceRequestDto>> ListTaskAsync(Guid OwnerId)
        {
            return _mapper.Map<List<ServiceRequestDto>>(await _context.ServiceRequests.Where(x=>x.UserId==OwnerId).ToListAsync());
        }

        public async Task<TaskExecutionDto> ListExecutionTaskAsync(Guid TaskId,Guid OwnerId)
        {
            var ownerTask = _context.ServiceRequests.FirstOrDefault(x => x.Id == TaskId);
            if (ownerTask == null || ownerTask.UserId != OwnerId)
                throw new BusinessException("Task not found.", 404);
            var executer = await _context.ServiceExecutions.Where(x => x.ServiceRequestId == TaskId)
                .Include(x => x.ExecutorUser).ThenInclude(t => t.SocialAccounts)
                .Include(x => x.ServiceRequest).ThenInclude(t => t.TargetSocialAccount)
                .ToListAsync();
            return new()
            {
                Id = ownerTask.Id,
                Reward = ownerTask.Price,
                Executers = executer.OrderByDescending(x => x.SubmittedAt)
                .GroupBy(x => x.SubmittedAt.Value.ToRelativeDate())
                .ToDictionary(
                g => g.Key,
                g => g.Select(x => new ServiceExecutionDto { Id = x.Id, ExecutorUserId = x.ExecutorUserId, ExecuterSeed = x.ExecutorUser.AvatarPath, ExecuterAccount = x.ExecutorUser.SocialAccounts.FirstOrDefault(s => s.Platform == x.ServiceRequest.TargetSocialAccount.Platform).ProfileName, Status = (int)x.Status, SubmittedAt = x.SubmittedAt.Value.ToRelativeTime() }).ToList())
            };
        }
        public async Task<TaskDto> CreateTaskAsync(TaskDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var wallet = _context.Wallets.FirstOrDefault(x => x.Id == request.OwnerId);
                if (wallet == null || wallet.TotalBalance <= 0)
                    throw new BusinessException("Wallet not found or insufficient balance.", 404);

                var totalAmount = request.ServiceRequest.Count * request.ServiceRequest.Price;
                if (wallet.TotalBalance < totalAmount) throw new BusinessException($"Total amount: {totalAmount}");

                wallet.TotalBalance -= totalAmount;
                wallet.BlockedAmount += totalAmount;

                var requestService = _mapper.Map<ServiceRequest>(request.ServiceRequest);
                requestService.Id = Guid.NewGuid();
                _context.ServiceRequests.Add(requestService);

                _context.WalletTransactions.Add(new()
                {
                    Amount = totalAmount,
                    Date = DateTime.UtcNow,
                    Description = $"Block for Task {requestService.Id}",
                    Type = WalletTransactionType.BlockForOrder,
                    Status = WalletTransactionStatus.Completed,
                    WalletId = wallet.Id
                });

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                if (_cache.TryGetValue(request.OwnerId, out UserSessionDto userSession))
                {
                    userSession.Balance = wallet.TotalBalance;
                    userSession.Block = wallet.BlockedAmount;
                    _cache.Set(request.OwnerId, userSession, TimeSpan.FromMinutes(30));
                }
                if (_cache.TryGetValue(AppSettings.AllTasks, out Dictionary<Guid, TaskSessionDto> tasks))
                {
                    tasks.Add(requestService.Id, new TaskSessionDto() { Price = requestService.Price, Title = requestService.Title, Url = requestService.TargetPostUrl });
                    _cache.Set(AppSettings.AllTasks, tasks);
                }
                return request;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<TaskApproveDto> TaskApproveAsync(TaskApproveDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var serviceExecute = _context.ServiceExecutions.Include(x => x.ServiceRequest).FirstOrDefault(x => x.Id == request.ServiceExecuteId && x.ServiceRequest.UserId == request.UserId);
                if (serviceExecute == null)
                    throw new BusinessException("ServiceExecute not found.", 404);

                serviceExecute.Status = ExecutionStatus.Approved;

                var walletOwner = _context.Wallets.FirstOrDefault(x => x.Id == serviceExecute.ServiceRequest.UserId);
                var walletWorker = _context.Wallets.FirstOrDefault(x => x.Id == serviceExecute.ExecutorUserId);

                walletOwner.BlockedAmount -= serviceExecute.Reward;
                walletWorker.TotalBalance += serviceExecute.Reward;

                _context.WalletTransactions.Add(new()
                {
                    Amount = serviceExecute.Reward,
                    Date = DateTime.UtcNow,
                    Description = $"Pay for Execute {serviceExecute.Id}",
                    Type = WalletTransactionType.PaymentToExecutor,
                    Status = WalletTransactionStatus.Completed,
                    WalletId = walletWorker.Id
                });

                _context.WalletTransactions.Add(new()
                {
                    Amount = serviceExecute.Reward,
                    Date = DateTime.UtcNow,
                    Description = $"Cost for Execute {serviceExecute.Id}",
                    Type = WalletTransactionType.PaymentToExecutor,
                    Status = WalletTransactionStatus.Completed,
                    WalletId = walletOwner.Id
                });

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                if (_cache.TryGetValue(serviceExecute.ServiceRequest.UserId, out UserSessionDto userOwner))
                {
                    userOwner.Balance = walletOwner.TotalBalance;
                    userOwner.Block = walletOwner.BlockedAmount;
                    _cache.Set(serviceExecute.ServiceRequest.UserId, userOwner, TimeSpan.FromMinutes(30));
                }
                if (_cache.TryGetValue(serviceExecute.ExecutorUserId, out UserSessionDto userWorker))
                {
                    userWorker.Balance = walletWorker.TotalBalance;
                    userWorker.Block = walletWorker.BlockedAmount;
                    _cache.Set(serviceExecute.ExecutorUserId, userWorker, TimeSpan.FromMinutes(30));
                }
                return request;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<TaskDoDto> TaskDoAsync(TaskDoDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var serviceRequest = _context.ServiceRequests.FirstOrDefault(x => x.Id == request.TaskId);
                var serviceRequestValid = true;
                if (serviceRequest.UserId == request.WorkerId)
                    throw new BusinessException("Task not Permit For Yourself.", 400);

                if (serviceRequest == null || serviceRequest.Status != ServiceRequestStatus.InProgress)
                    throw new BusinessException("Task not found or InActive.", 404);

                var wallet = _context.Wallets.FirstOrDefault(x => x.Id == serviceRequest.UserId);
                if (!serviceRequest.IsDefault)
                {
                    if (serviceRequest.Count > serviceRequest.CountDo)
                    {
                        serviceRequest.CountDo++;
                    }
                    else
                    {
                        if (_cache.TryGetValue(AppSettings.AllTasks, out Dictionary<Guid, TaskSessionDto> tasks))
                        {
                            tasks.Remove(serviceRequest.Id);
                            _cache.Set(AppSettings.AllTasks, tasks);
                        }
                        serviceRequest.Status = ServiceRequestStatus.Completed;
                        serviceRequestValid = false;
                    }
                }
                else
                {
                    if (serviceRequest.IsDefault && wallet.TotalBalance < serviceRequest.Price)
                        serviceRequestValid = false;
                    else
                        serviceRequest.CountDo++;
                }

                if (serviceRequestValid)
                {
                    var execution = new ServiceExecution()
                    {
                        ServiceRequestId = serviceRequest.Id,
                        ExecutorUserId = request.WorkerId,
                        Reward = serviceRequest.Price,
                        SubmittedAt = DateTime.UtcNow,
                        Status = ExecutionStatus.WaitingForApproval,
                    };

                    _context.ServiceExecutions.Add(execution);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                if (serviceRequestValid)
                {
                    if (_cache.TryGetValue(request.WorkerId, out UserSessionDto userWorker))
                    {
                        userWorker.DoneTask++;
                        _cache.Set(request.WorkerId, userWorker, TimeSpan.FromMinutes(30));
                    }
                }

                return request;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task InitTaskAsync()
        {
            var tasks = await _context.ServiceRequests.Where(t => t.Status == ServiceRequestStatus.InProgress).Include(c=> c.TargetSocialAccount).ThenInclude(t=> t.User)
                .ToDictionaryAsync(x => x.Id, y => new TaskSessionDto() { Price = y.Price, Title = y.Title, Url = y.TargetPostUrl , UserAvatar = y.TargetSocialAccount.User.AvatarPath , UserName = y.TargetSocialAccount.ProfileName });
            _cache.Set(AppSettings.AllTasks, tasks);
        }

        public async Task<bool> TaskCancelAsync(TaskDoDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var serviceRequest = _context.ServiceRequests.FirstOrDefault(x => x.Id == request.TaskId);

                if (serviceRequest == null)
                    throw new BusinessException("Task not found or InActive.", 404);
                if (serviceRequest.UserId == request.WorkerId)
                    throw new BusinessException("Task not Permit For Yourself.", 400);

                var execution = _context.ServiceExecutions.FirstOrDefault(x => x.ServiceRequestId == serviceRequest.Id && x.ExecutorUserId == request.WorkerId);
                if (execution == null || execution.Status != ExecutionStatus.WaitingForApproval)
                    throw new BusinessException("Execution Not Active.", 404);

                var wallet = _context.Wallets.FirstOrDefault(x => x.Id == serviceRequest.UserId);
                serviceRequest.CountDo--;


                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                if (_cache.TryGetValue(request.WorkerId, out UserSessionDto userWorker))
                {
                    userWorker.DoneTask--;
                    _cache.Set(request.WorkerId, userWorker, TimeSpan.FromMinutes(30));
                }

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<List<RemainDto>> RemainTaskAsync(Guid UserId)
        {
            return await(
                 from t in _context.ServiceRequests
                 join udt in _context.ServiceExecutions
                     on new { t.Id, UserId } equals new { Id = udt.ServiceRequestId, UserId = udt.ExecutorUserId }
                     into gj
                 from sub in gj.DefaultIfEmpty()
                 where sub == null && t.UserId != UserId
                 orderby Guid.NewGuid()
                 select new RemainDto { Id = t.Id , Do = false , Seen = false }
             ).Take(20).ToListAsync();
        }

        public async Task<TaskDetailDto?> GetDetailAsync(Guid id)
        {
            if (_cache.TryGetValue(AppSettings.AllTasks, out Dictionary<Guid,TaskSessionDto> tasks))
            {
                if (tasks.TryGetValue(id, out TaskSessionDto detail))
                {
                    return new() { Id = id, Detail = detail };
                }
                else
                    throw new BusinessException("Task Not Found.", 401);
            }
            else
            {
                return default;
            }
        }
    }
}
