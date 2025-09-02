using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoCast.App.Common.Dtos;
using NoCast.App.Models;

namespace NoCast.App.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseCustomerController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("set-avatar")]
        public async Task<IActionResult> SetAvatar([FromBody] UserDto request)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            if (user == null)
                return NotFound();

            user.AvatarPath = request.Avatar;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return ApiError("ثبت با خطا همراه بود",result.Errors.Select(x=> x.Description).ToList());
            return ApiOk("Success");
        }

        [HttpPost("set-password")]
        public async Task<IActionResult> SetPassword([FromBody] ResetPasswordDto request)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            if (user == null)
                return NotFound();

            // اگر یوزر قبلاً پسورد نداشته باشه
            if (!await _userManager.HasPasswordAsync(user))
            {
                var addResult = await _userManager.AddPasswordAsync(user, request.Password);
                if (!addResult.Succeeded)
                    return BadRequest(addResult.Errors);
            }
            else
            {
                // در غیر اینصورت پسورد فعلی نیاز نیست، می‌تونیم مستقیم ریست کنیم
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetResult = await _userManager.ResetPasswordAsync(user, token, request.Password);

                if (!resetResult.Succeeded)
                    return BadRequest(resetResult.Errors);
            }

            return Ok(new { message = "ثبت با موفقیت اعمال شد" });

        }
    }
}
