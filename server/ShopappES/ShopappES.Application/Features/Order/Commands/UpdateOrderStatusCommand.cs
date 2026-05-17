using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Domain.Enums;

namespace ShopappES.Application.Features.Order.Commands;

public class UpdateOrderStatusCommand : IRequest<ApiResponse<OrderDto>>
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
}
