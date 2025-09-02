
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class AIContentRequestDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "User Id")]
        public Guid UserId { get; set; }
        [Display(Name = "Prompt")]
        public string Prompt { get; set; }
        [Display(Name = "Result")]
        public string Result { get; set; }
        [Display(Name = "Requested At")]
        public DateTime? RequestedAt { get; set; }
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }
    }
}