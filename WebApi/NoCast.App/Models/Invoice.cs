namespace NoCast.App.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public string BuyerId { get; set; }
        public ApplicationUser Buyer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public ICollection<InvoiceItem> Items { get; set; }
    }

}
