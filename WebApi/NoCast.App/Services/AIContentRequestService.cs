
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NoCast.App.Data;
using NoCast.App.Models;
using NoCast.App.Services.Interfaces;
using NoCast.App.Contract.Services;
using NoCast.App.Dtos;

namespace NoCast.App.Services
{
    public class AIContentRequestService : GenericService<AIContentRequest, AIContentRequestDto>, IAIContentRequestService
    {
        public AIContentRequestService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}