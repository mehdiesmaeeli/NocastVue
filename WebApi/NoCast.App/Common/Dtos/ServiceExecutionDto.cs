
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class ServiceExecutionDto
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public Guid ExecutorUserId { get; set; }
        public string ExecuterSeed { get; set; }
        public string ExecuterAccount { get; set; }
        public Guid ExecutorSocialAccountId { get; set; }
        public int Status { get; set; }
        public string SubmittedAt { get; set; }
        public string ApprovedAt { get; set; }
        public decimal Reward { get; set; }
    }
}