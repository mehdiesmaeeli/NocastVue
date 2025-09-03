using NoCast.App.Common.Dtos;

namespace NoCast.App.Contract.Services
{
    public interface IApplicationTaskService
    {
        Task<TaskDto> CreateTaskAsync(TaskDto request);
        Task<TaskDoDto> TaskDoAsync(TaskDoDto request);
        Task<TaskApproveDto> TaskApproveAsync(TaskApproveDto request);
        Task InitTaskAsync();
    }
}
