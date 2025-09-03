using Microsoft.AspNetCore.Identity;

namespace NoCast.App.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? AvatarPath { get; set; }
        public string PhoneNumber { get; set; }
        public Wallet Wallet { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<ServiceRequest> Requests { get; set; }
        public ICollection<ServiceExecution> Executions { get; set; }
    }

    public class ApplicationRole : IdentityRole<Guid> {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
