
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class ServiceRequestDto
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TargetSocialAccountId { get; set; }
        public string TargetPostUrl { get; set; }
        public byte? Status { get; set; }
        public byte Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public bool IsDefault { get; set; }
    }
}