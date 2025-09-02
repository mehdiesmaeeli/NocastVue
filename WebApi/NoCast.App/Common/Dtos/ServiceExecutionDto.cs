
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class ServiceExecutionDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Service Request Id")]
        public Guid ServiceRequestId { get; set; }
        [Display(Name = "Executor User Id")]
        public Guid ExecutorUserId { get; set; }
        [Display(Name = "Executor Social Account Id")]
        public Guid ExecutorSocialAccountId { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        [Display(Name = "Submitted At")]
        public List<string> SubmittedAt { get; set; }
        [Display(Name = "Approved At")]
        public List<string> ApprovedAt { get; set; }
        [Display(Name = "Reward")]
        public decimal Reward { get; set; }
    }
}