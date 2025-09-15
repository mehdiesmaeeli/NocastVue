using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NoCast.App.Common.Dtos;
using NoCast.App.Contract.Services;
using NoCast.App.Data;
using NoCast.App.Migrations;
using NoCast.App.Models;
using static System.Net.WebRequestMethods;

namespace NoCast.App.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ApplicationUserService(ApplicationDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<UserSessionDto> CreateSessionAsync(Guid UserId)
        {
            var result = await FillWallet(UserId);
            _cache.Set(UserId, result, TimeSpan.FromMinutes(30));
            return result;
        }

        public async Task<UserSessionDto> GetSessionAsync(Guid UserId)
        {
            if (!_cache.TryGetValue(UserId, out UserSessionDto userSession))
                return await CreateSessionAsync(UserId);
            else
                return userSession;
        }
        private async Task<UserSessionDto> FillWallet(Guid UserId)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var wallet = _context.Wallets.FirstOrDefault(x => x.Id == UserId);
            var todayCnt = await _context.ServiceExecutions.CountAsync(x => x.ExecutorUserId == UserId && x.SubmittedAt >= today && x.SubmittedAt < tomorrow);
            return new UserSessionDto() { Balance = wallet.TotalBalance, Block = wallet.BlockedAmount, DoneTask = (byte)todayCnt };
        }

        public async Task<bool> BanUserAsync(Guid UserId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = _context.Users.Include(x => x.Wallet).FirstOrDefault(x => x.Id == UserId);
                user.IsActive = false;
                var balance = user.Wallet.TotalBalance;
                if (balance > 0)
                {
                    user.Wallet.TotalBalance -= balance;
                    user.Wallet.BlockedAmount += balance;
                    _context.WalletTransactions.Add(new()
                    {
                        Amount = balance,
                        Date = DateTime.UtcNow,
                        Description = $"Ban Wallet",
                        Type = WalletTransactionType.BlockForOrder,
                        Status = WalletTransactionStatus.Completed,
                        WalletId = user.Wallet.Id
                    });
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                if (!_cache.TryGetValue(UserId, out UserSessionDto userSession))
                    _cache.Remove(UserId);
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
