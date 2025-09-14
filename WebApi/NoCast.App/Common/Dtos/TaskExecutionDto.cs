
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
        public DateTime SubmittedAt { get; set; }
        public DateTime ApprovedAt { get; set; }
        public decimal Reward { get; set; }
        public Dictionary<string, List<ServiceExecutionDto>> Executers { get; set; }
    }
}