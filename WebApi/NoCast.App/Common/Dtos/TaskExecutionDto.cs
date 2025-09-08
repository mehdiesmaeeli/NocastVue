
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class TaskExecutionDto
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public Guid ExecutorUserId { get; set; }
        public Guid ExecutorSocialAccountId { get; set; }
        public int Status { get; set; }
        public List<string> SubmittedAt { get; set; }
        public List<string> ApprovedAt { get; set; }
        public decimal Reward { get; set; }
        public List<ServiceExecutionDto> Executers { get; set; }
    }
}