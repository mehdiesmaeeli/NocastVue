using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NoCast.App.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public abstract class BaseAdminController : BaseController
    {
        protected Guid UserId => Guid.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        protected string UserName => User?.Identity?.Name;
        protected string? GetClaim(string claimType)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}
