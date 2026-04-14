using ShopappES.Domain.Entity;
using ShopappES.Application.Features.Product.DTOs;

namespace ShopappES.Application.Features.Order.DTOs;

public class OrderDetailDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public OrderDto? Order { get; set; }
    public Guid ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
