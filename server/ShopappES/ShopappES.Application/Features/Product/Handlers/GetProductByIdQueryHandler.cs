using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.DTOs;
using ShopappES.Application.Features.Product.Queries;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Product.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDto>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Repository<Domain.Entity.Product>()
            .GetAll(p => p.Id == request.Id && !p.IsDeleted)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(cancellationToken);

        if (product == null)
        {
            return ApiResponse<ProductDto>.FailResponse("Product not found", 404);
        }

        var dto = _mapper.Map<ProductDto>(product);
        return ApiResponse<ProductDto>.SuccessResponse(dto, "Product retrieved successfully");
    }
}
