using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Order.Queries;

public class GetAllOrdersQuery : IRequest<ApiResponse<List<OrderDto>>>
{
}
