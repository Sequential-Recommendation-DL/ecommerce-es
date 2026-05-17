using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Order.Commands;

public class CreateOrderCommand : IRequest<ApiResponse<OrderDto>>
{
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public string? Note { get; set; }
    public Guid? CouponId { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}
