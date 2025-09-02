namespace NoCast.App.Models
{
    public class AIContentRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Prompt { get; set; }
        public string Result { get; set; }
        public DateTime RequestedAt { get; set; }
        public decimal Cost { get; set; }
    }

}
