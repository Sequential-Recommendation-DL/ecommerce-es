using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;
using ShopappES.Domain.Enums;

namespace ShopappES.Domain.Entity
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string? TransactionId { get; set; }
        public string? PaymentNote { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public string? PaymentUrl { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
