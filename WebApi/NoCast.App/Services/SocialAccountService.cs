using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoCast.App.Data;
using NoCast.App.Dtos;
using NoCast.App.Models;
using NoCast.App.Services.Interfaces;

namespace NoCast.App.Services
{
    public class SocialAccountService : GenericService<SocialAccount, SocialAccountDto>, ISocialAccountService
    {
        public SocialAccountService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<string> CheckUserPlatform(SocialAccountDto model)
        {
            var result = "";
            if (_dbSet.Any(x=> x.UserId == model.UserId && x.Platform == (SocialPlatform)model.Platform))
                result = "برای این پلتفرم قبلا اطلاعات ثبت شده است";
            return result;
        }

        public async Task<List<SocialAccountDto>> GetAllSocialAccountByUser(Guid userId)
        {
            var entities = await _dbSet.Where(x => x.UserId == userId && x.IsVerified && x.Platform == SocialPlatform.Instagram )
                .Select(x=> _mapper.Map<SocialAccountDto>(x)).ToListAsync();
            return entities;
        }
    }
}