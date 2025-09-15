using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoCast.App.Common.Dtos;
using NoCast.App.Common.Statics;
using NoCast.App.Contract.Services;
using NoCast.App.Dtos;
using NoCast.App.Services.Interfaces;

namespace NoCast.App.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseCustomerController
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IApplicationTaskService _applicationTaskService;
        private readonly IApplicationUserService _applicationUserService;

        public TaskController(IServiceRequestService serviceRequestService, IApplicationTaskService applicationTaskService, IApplicationUserService applicationUserService)
        {
            _serviceRequestService = serviceRequestService;
            _applicationTaskService = applicationTaskService;
            _applicationUserService = applicationUserService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var sessionUser = await _applicationUserService.GetSessionAsync(UserId);
            var detail = await _applicationTaskService.GetDetailAsync(id);
            detail.TodayCnt = sessionUser.DoneTask;
            detail.GiftCnt = 99;
            return ApiOk(detail, "Success");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var res= await _applicationTaskService.ListTaskAsync(UserId);
            return ApiOk(res, "Success");
        }

        [HttpGet("remain")]
        public async Task<IActionResult> GetRemain()
        {
            var result = await _applicationTaskService.RemainTaskAsync(UserId);
            return ApiOk(result, "Success");
        }

        [HttpGet("activity/{taskId}")]
        public async Task<IActionResult> GetActivity(Guid taskId)
        {
            var result = await _applicationTaskService.ListExecutionTaskAsync(taskId, UserId);
            return ApiOk(result, "Success");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceRequestDto modelDto)
        {
            modelDto.UserId = UserId;
            var result = await _applicationTaskService.CreateTaskAsync(new() { OwnerId = UserId , ServiceRequest = modelDto});
            return ApiOk(result, "Success");
        }

        [HttpPost("do")]
        public async Task<IActionResult> Do([FromBody] TaskDoDto modelDto)
        {
            modelDto.WorkerId = UserId;
            var result = await _applicationTaskService.TaskDoAsync(modelDto);
            return ApiOk(result, "Success");
        }

        [HttpPost("approve")]
        public async Task<IActionResult> Approve([FromBody] TaskApproveDto modelDto)
        {
            modelDto.UserId = UserId;
            var result = await _applicationTaskService.TaskApproveAsync(modelDto);
            return ApiOk(result, "Success");
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel([FromBody] TaskApproveDto modelDto)
        {
            modelDto.UserId = UserId;
            var result = await _applicationTaskService.TaskApproveAsync(modelDto);
            return ApiOk(result, "Success");
        }
    }
}
