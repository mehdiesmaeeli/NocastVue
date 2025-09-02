
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class PaymentGatewayLogDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "User Id")]
        public Guid UserId { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Gateway Ref Id")]
        public string GatewayRefId { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}