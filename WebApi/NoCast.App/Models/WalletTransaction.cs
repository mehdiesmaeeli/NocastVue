namespace NoCast.App.Models
{
    public class WalletTransaction
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public WalletTransactionType Type { get; set; }
        public WalletTransactionStatus Status { get; set; }

    }

    public enum WalletTransactionType
    {
        Recharge,           // شارژ کیف پول
        BlockForOrder,      // بلاک کردن موجودی برای یک سرویس
        Unblock,            // آزادسازی موجودی بلاک‌شده
        PaymentToExecutor,  // پرداخت به مجری
        Refund              // بازگشت پول به کاربر
    }

    public enum WalletTransactionStatus
    {
        Pending,   // هنوز نهایی نشده
        Completed, // نهایی شده
        Cancelled  // لغو شده یا برگشت داده شده
    }
}
