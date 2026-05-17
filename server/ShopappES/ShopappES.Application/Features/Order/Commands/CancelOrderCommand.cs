using MediatR;
using ShopappES.Application.Common;

namespace ShopappES.Application.Features.Order.Commands;

public class CancelOrderCommand : IRequest<ApiResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
