
using AutoMapper;
using NoCast.App.Dtos;
using NoCast.App.Models;
using NoCast.App.Services.Interfaces;

namespace NoCast.App.Mappings
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<ServiceRequest, ServiceRequestDto>().ReverseMap();
            CreateMap<SocialAccount, SocialAccountDto>().ReverseMap();
        }
    }
}