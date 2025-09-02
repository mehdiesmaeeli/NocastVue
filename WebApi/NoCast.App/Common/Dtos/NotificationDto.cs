
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class NotificationDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "User Id")]
        public Guid UserId { get; set; }
        [Display(Name = "Message")]
        public string Message { get; set; }
        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Is Read")]
        public bool IsRead { get; set; }
    }
}