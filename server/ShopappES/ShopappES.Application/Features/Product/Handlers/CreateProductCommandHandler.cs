using AutoMapper;
using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.Commands;
using ShopappES.Application.Features.Product.DTOs;
using ShopappES.Domain.Entity;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Product.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<ProductDto>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var existing = _unitOfWork.Repository<Domain.Entity.Product>().GetAll()
            .FirstOrDefault(p => p.SKU == request.SKU && !p.IsDeleted);

        if (existing != null)
        {
            return ApiResponse<ProductDto>.FailResponse("SKU already exists", 400);
        }

        var product = new Domain.Entity.Product
        {
            ProductName = request.ProductName,
            ProductDescription = request.ProductDescription,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            StockQuantity = request.StockQuantity,
            ProductImage = request.ProductImage,
            Images = request.Images,
            Thumbnail = request.Thumbnail,
            SKU = request.SKU,
            CategoryId = request.CategoryId,
            IsActive = request.IsActive,
            IsFeatured = request.IsFeatured,
            Brand = request.Brand,
            Weight = request.Weight,
            Dimensions = request.Dimensions
        };

        await _unitOfWork.Repository<Domain.Entity.Product>().AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<ProductDto>(product);
        return ApiResponse<ProductDto>.SuccessResponse(dto, "Product created successfully", 201);
    }
}
