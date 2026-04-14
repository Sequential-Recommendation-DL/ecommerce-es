using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Shipping.DTOs;

public class ShippingDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public OrderDto? Order { get; set; }
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

public enum ShippingStatus
{
    Pending,
    PickupScheduled,
    PickedUp,
    InTransit,
    OutForDelivery,
    Delivered,
    Failed,
    Returned,
    Cancelled
}
