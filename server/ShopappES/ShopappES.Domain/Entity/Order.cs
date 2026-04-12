using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;
using ShopappES.Domain.Enums;

namespace ShopappES.Domain.Entity;

public class Order : BaseEntity
{
    public string OrderCode { get; set; } = string.Empty;
    [Required(ErrorMessage = "Mã người dùng không được để trống")]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal? FinalAmount { get; set; }
    public string? Note { get; set; }
    public Guid? AddressId { get; set; }
    public Address? Address { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public Payment? Payment { get; set; }
    public Shipping? Shipping { get; set; }
    public Guid? CouponId { get; set; }
    public Coupon? Coupon { get; set; }
}
