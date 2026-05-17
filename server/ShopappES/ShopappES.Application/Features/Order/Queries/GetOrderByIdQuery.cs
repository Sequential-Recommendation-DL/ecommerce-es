using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Order.Queries;

public class GetOrderByIdQuery : IRequest<ApiResponse<OrderDto>>
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
}
