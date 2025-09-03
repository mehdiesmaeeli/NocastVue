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

        public TaskController(IServiceRequestService serviceRequestService, IApplicationTaskService applicationTaskService)
        {
            _serviceRequestService = serviceRequestService;
            _applicationTaskService = applicationTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return ApiOk(new { id = 1, todayCnt = 1, giftCnt = 99 , title = "asdasdasd" , url = "/asd/asd" , price = 1 }, "Success");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var list = new[]
            {
                new { id = 1, name = "علی" ,type=0 },
                new { id = 2, name = "رضا" ,type=1},
                new { id = 3, name = "سارا",type=2}
            };
            return ApiOk(list, "Success");
        }

        [HttpGet("activity")]
        public async Task<IActionResult> GetActivity()
        {
            var list = new[]
            {
                new { id = 1, name = "علی" , date = DateTime.Now.AddDays(-2) , isPay=false },
                new { id = 12, name = "علی" , date = DateTime.Now.AddDays(-2) , isPay=true },
                new { id = 13, name = "علی" , date = DateTime.Now.AddDays(-2) , isPay=false },
                new { id = 14, name = "علی" , date = DateTime.Now.AddDays(-2) , isPay=false },
                new { id = 21, name = "رضا" , date = DateTime.Now.AddDays(-32) , isPay=false},
                new { id = 22, name = "رضا" , date = DateTime.Now.AddDays(-32) , isPay=true},
                new { id = 23, name = "رضا" , date = DateTime.Now.AddDays(-32) , isPay=false},
                new { id = 24, name = "رضا" , date = DateTime.Now.AddDays(-32) , isPay=false},
                new { id = 31, name = "سارا", date = DateTime.Now , isPay=true},
                new { id = 32, name = "سارا", date = DateTime.Now , isPay=true},
                new { id = 33, name = "سارا", date = DateTime.Now , isPay=false},
                new { id = 34, name = "سارا", date = DateTime.Now , isPay=true},
                new { id = 35, name = "سارا", date = DateTime.Now , isPay=true},
            };
            var result = new { id = 1, name = "tetst dfsdf", list = list.OrderByDescending(x=> x.date).GroupBy(x=> x.date.ToRelativeDate()).ToDictionary(g => g.Key, g => g.Select(x=> new {x.id ,x.name,x.isPay, time = x.date.ToRelativeTime() }).ToList())};
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
    }
}
