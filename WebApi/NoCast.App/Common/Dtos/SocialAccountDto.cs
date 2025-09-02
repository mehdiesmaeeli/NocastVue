
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class SocialAccountDto
    {
        [Display(Name = "Id")]
        public Guid? Id { get; set; }
        [Display(Name = "User Id")]
        public Guid? UserId { get; set; }
        [Display(Name = "Platform")]
        public int Platform { get; set; }
        [Display(Name = "Profile Name")]
        public string ProfileName { get; set; }
        [Display(Name = "Is Verified")]
        public bool? IsVerified { get; set; }
        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; }
        
    }
}