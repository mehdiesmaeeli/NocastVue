using NoCast.App.Common.Dtos;
using NoCast.App.Dtos;

namespace NoCast.App.Contract.Services
{
    public interface IApplicationTaskService
    {
        Task<TaskDto> CreateTaskAsync(TaskDto request);
        Task<List<ServiceRequestDto>> ListTaskAsync(Guid OwnerId);
        Task<TaskExecutionDto> ListExecutionTaskAsync(Guid TaskId, Guid OwnerId);
        Task<TaskDoDto> TaskDoAsync(TaskDoDto request);
        Task<TaskApproveDto> TaskApproveAsync(TaskApproveDto request);
        Task<bool> TaskCancelAsync(TaskDoDto request);
        Task InitTaskAsync();
        Task<List<Guid>> RemainTaskAsync(Guid UserId);
    }
}
