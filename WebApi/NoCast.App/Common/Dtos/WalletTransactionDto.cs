
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class WalletTransactionDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Wallet Id")]
        public Guid WalletId { get; set; }
        [Display(Name = "Date")]
        public DateTime? Date { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Type")]
        public int Type { get; set; }
    }
}