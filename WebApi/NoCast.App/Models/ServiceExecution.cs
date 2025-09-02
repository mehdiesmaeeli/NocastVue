namespace NoCast.App.Models
{
    public class ServiceExecution
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public Guid ExecutorUserId { get; set; }
        public Guid ExecutorSocialAccountId { get; set; } // اکانتی که باهاش کار رو انجام داده
        public ExecutionStatus Status { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public decimal Reward { get; set; } // پس از تایید به کیف پول انجام‌دهنده واریز می‌شود
    }

    public enum ExecutionStatus
    {
        WaitingForApproval,
        Approved,
        Rejected
    }

}
