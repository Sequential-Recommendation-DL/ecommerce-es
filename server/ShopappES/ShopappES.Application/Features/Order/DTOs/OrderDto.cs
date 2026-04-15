using ShopappES.Domain.Entity;
using ShopappES.Domain.Enums;
using ShopappES.Application.Features.Payment.DTOs;
using ShopappES.Application.Features.Shipping.DTOs;
using ShopappES.Application.Features.Auth.DTOs;

namespace ShopappES.Application.Features.Order.DTOs;

public class OrderDto
{
    public Guid Id { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal? FinalAmount { get; set; }
    public string? Note { get; set; }
    public Guid? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public Guid? CouponId { get; set; }
    public CouponDto? Coupon { get; set; }
    public List<OrderDetailDto>? OrderDetails { get; set; }
    public ShippingDto? Shipping { get; set; }
    public PaymentDto? Payment { get; set; }
}
