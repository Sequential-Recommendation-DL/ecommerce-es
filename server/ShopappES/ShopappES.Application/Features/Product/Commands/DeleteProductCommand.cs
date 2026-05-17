using MediatR;
using ShopappES.Application.Common;

namespace ShopappES.Application.Features.Product.Commands;

public class DeleteProductCommand : IRequest<ApiResponse>
{
    public Guid Id { get; set; }
}
