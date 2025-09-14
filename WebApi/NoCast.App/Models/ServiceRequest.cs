namespace NoCast.App.Models
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TargetSocialAccountId { get; set; } // اکانتی که قراره روی اون کاری انجام بشه
        public string TargetPostUrl { get; set; } // لینک پستی که کار باید روی اون انجام بشه
        public ServiceRequestStatus Status { get; set; }
        public ServiceRequestType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CountDo { get; set; }
        public bool IsDefault { get; set; }
        public ICollection<ServiceExecution> Executions { get; set; }
        public SocialAccount TargetSocialAccount { get; set; }
    }

    public enum ServiceRequestStatus : byte
    {
        Pending,
        InProgress,
        Completed,
        Canceled
    }

    public enum ServiceRequestType : byte
    {
        All,
        Follow,
        Like,
        Watch,
        Repost,
        Comment
    }
}
