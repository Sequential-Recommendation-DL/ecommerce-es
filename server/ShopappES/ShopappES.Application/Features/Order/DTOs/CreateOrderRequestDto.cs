namespace ShopappES.Application.Features.Order.DTOs;

public class CreateOrderRequestDto
{
    public Guid AddressId { get; set; }
    public string? Note { get; set; }
    public Guid? CouponId { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
