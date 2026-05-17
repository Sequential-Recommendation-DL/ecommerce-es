using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.DTOs;
using ShopappES.Application.Features.Product.Queries;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Product.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<List<ProductDto>>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Repository<Domain.Entity.Product>()
            .GetAll(p => !p.IsDeleted)
            .Include(p => p.Category)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<ProductDto>>(products);
        return ApiResponse<List<ProductDto>>.SuccessResponse(dtos, "Products retrieved successfully");
    }
}
