using NoCast.App.Common.Dtos;

namespace NoCast.App.Contract.Services
{
    public interface IApplicationUserService
    {
        Task<UserSessionDto> CreateSessionAsync(Guid UserId);
        Task<UserSessionDto> GetSessionAsync(Guid UserId);
        Task<bool> BanUserAsync(Guid UserId);
    }
}
