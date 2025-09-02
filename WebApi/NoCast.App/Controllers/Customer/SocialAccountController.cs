using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoCast.App.Common.Dtos;
using NoCast.App.Common.Statics;
using NoCast.App.Dtos;
using NoCast.App.Services;
using NoCast.App.Services.Interfaces;

namespace NoCast.App.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialAccountController : BaseCustomerController
    {
        private readonly ISocialAccountService _socialAccountService;

        public SocialAccountController(ISocialAccountService socialAccountService)
        {
            _socialAccountService = socialAccountService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _socialAccountService.GetAllSocialAccountByUser(UserId);
            return ApiOk(result, "Success");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SocialAccountDto modelDto)
        {
            modelDto.Platform = 0;
            modelDto.UserId = UserId;
            modelDto.IsVerified = true;
            await _socialAccountService.CreateAsync(modelDto);
            return ApiOk("");
        }
    }
}
