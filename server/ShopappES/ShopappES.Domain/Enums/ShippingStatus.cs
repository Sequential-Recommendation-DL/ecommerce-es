namespace ShopappES.Domain.Enums;

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