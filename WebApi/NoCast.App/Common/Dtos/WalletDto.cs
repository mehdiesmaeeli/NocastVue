
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class WalletDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "TotalBalance")]
        public decimal TotalBalance { get; set; }
        [Display(Name = "BlockedAmount")]
        public decimal BlockedAmount { get; set; }
        [Display(Name = "AvailableBalance")]
        public decimal AvailableBalance { get; set; }
        [Display(Name = "Transactions")]
        public List<WalletTransactionDto> Transactions { get; set; }
    }
}