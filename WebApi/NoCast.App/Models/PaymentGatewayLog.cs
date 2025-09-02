namespace NoCast.App.Models
{
    public class PaymentGatewayLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string GatewayRefId { get; set; }
        public string Status { get; set; }
    }
}
