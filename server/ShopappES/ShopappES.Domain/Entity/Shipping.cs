using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;
using ShopappES.Domain.Enums;

namespace ShopappES.Domain.Entity
{
    public class Shipping : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public ShippingStatus Status { get; set; } = ShippingStatus.Pending;
        public string? Carrier { get; set; }
        public string? TrackingNumber { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public decimal ShippingFee { get; set; }
        public string? Notes { get; set; }
    }
}
