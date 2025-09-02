using System.ComponentModel.DataAnnotations.Schema;

namespace NoCast.App.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }

        // موجودی کل (آزاد + بلاک‌شده)
        public decimal TotalBalance { get; set; }

        // موجودی بلاک‌شده (هنوز هزینه نشده)
        public decimal BlockedAmount { get; set; }

        [NotMapped]
        public decimal AvailableBalance => TotalBalance - BlockedAmount;

        [ForeignKey(nameof(Id))]
        public ApplicationUser User { get; set; }
        public ICollection<WalletTransaction> Transactions { get; set; }
    }
}
