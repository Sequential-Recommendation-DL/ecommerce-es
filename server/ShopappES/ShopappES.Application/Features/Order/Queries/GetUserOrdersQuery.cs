using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Order.Queries;

public class GetUserOrdersQuery : IRequest<ApiResponse<List<OrderDto>>>
{
    public Guid UserId { get; set; }
}
