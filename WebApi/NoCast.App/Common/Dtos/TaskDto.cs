using NoCast.App.Dtos;

namespace NoCast.App.Common.Dtos
{
    public class TaskDto
    {
        public Guid OwnerId { get; set; }
        public ServiceRequestDto ServiceRequest { get; set; }

    }
}
