using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.DTOs;

namespace ShopappES.Application.Features.Product.Queries;

public class GetAllProductsQuery : IRequest<ApiResponse<List<ProductDto>>>
{
}
