namespace NoCast.App.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
        public MessageType Type { get; set; }

        // Navigation properties
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }

    public enum MessageType
    {
        Direct = 1,
        Group = 2,
        System = 3
    }
}
