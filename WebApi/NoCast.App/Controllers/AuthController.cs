using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using NoCast.App.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using NoCast.App.Common.Dtos;
using NoCast.App.Common.Statics;
using Microsoft.Extensions.Caching.Memory;

namespace NoCast.App.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMemoryCache _cache;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(IMemoryCache cache,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _cache = cache;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto modelDto)
        {
            var user = new ApplicationUser { UserName = modelDto.Phone, PhoneNumber = modelDto.Phone };
            var result = await _userManager.CreateAsync(user, modelDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, AppRoles.Customer);
                await _userManager.AddClaimAsync(user, new Claim("RegisteredAt", DateTime.UtcNow.ToString("o")));
                await _userManager.AddClaimAsync(user, new Claim("AccessLevel", "Basic"));
                return ApiOk("User registered successfully");
            }
            var errors = result.Errors.Select(e => e.Description).ToList();
            return ApiError("Registration failed", errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto modelDto)
        {
            var user = await _userManager.FindByNameAsync(modelDto.Phone);
            if (user == null)
                return ApiUnauthorized("کاربری با این ایمیل پیدا نشد.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, modelDto.Password);
            if (!isPasswordValid)
                return ApiUnauthorized("رمز عبور اشتباه است.");

            var token = await GenerateJwtToken(user);
            return ApiOk(token, "Login successful");
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] OtpDto request)
        {
            var otp = new Random().Next(1000, 9999).ToString();
            // ذخیره OTP با زمان انقضای 2 دقیقه
           
            var token = Guid.NewGuid().ToString();
            var otpKey = $"otp:{token}";
            _cache.Set(otpKey, $"{request.Phone}:{otp}", TimeSpan.FromMinutes(5));
            // TODO: اینجا باید سرویس SMS (مثل کاوه‌نگار یا Twilio) وصل بشه
            Console.WriteLine($"OTP for {request.Phone} is {otp}");

            return ApiOk(new { otpToken = token });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpDto request)
        {
            var otpKey = $"otp:{request.Token}";
            var attemptsKey = $"attempts:{request.Token}";


            if (!_cache.TryGetValue(otpKey, out string expectedOtp))
            {
                return ApiError("کد منقضی شده است.");
            }

            if (request.Otp != expectedOtp.Split(':')[1])
            {
                int attempts = _cache.GetOrCreate(attemptsKey, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                    return 1;
                });
                if (attempts >= 5)
                {
                    return ApiError("تعداد تلاش بیش از حد مجاز است.");
                }
                _cache.Set(attemptsKey, attempts + 1, TimeSpan.FromMinutes(2));
                return ApiError("کد نادرست است.");
            }
            var phoneNumber = expectedOtp.Split(':')[0];
            var regist = await RegisterUserAsync(new RegisterDto { Phone = phoneNumber });
            if (regist.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(phoneNumber);
                var token = await GenerateJwtToken(user);
                _cache.Remove(otpKey);
                _cache.Remove(attemptsKey);
                return ApiOk(token, "Register successful");
            }
            var errors = regist.Errors.Select(e => e.Description).ToList();
            return ApiError("Registration failed", errors);
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            }
            ;

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.AddRange(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IdentityResult> RegisterUserAsync(RegisterDto modelDto)
        {
            var user = new ApplicationUser { UserName = modelDto.Phone, PhoneNumber = modelDto.Phone };
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, AppRoles.Customer);
                await _userManager.AddClaimAsync(user, new Claim("RegisteredAt", DateTime.UtcNow.ToString("o")));
                await _userManager.AddClaimAsync(user, new Claim("AccessLevel", "Basic"));
                return result;
            }

            return result;
        }
    }
}