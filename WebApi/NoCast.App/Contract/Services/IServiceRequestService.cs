
using System.Collections.Generic;
using System.Threading.Tasks;
using NoCast.App.Contract.Services;
using NoCast.App.Dtos;
using NoCast.App.Models;

namespace NoCast.App.Services.Interfaces
{
    public interface IServiceRequestService : IGenericService<ServiceRequest, ServiceRequestDto>
    {

    }
}