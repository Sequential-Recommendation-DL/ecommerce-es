using AutoMapper;
using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.Commands;
using ShopappES.Application.Features.Product.DTOs;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Product.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<ProductDto>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Repository<Domain.Entity.Product>().GetByIdAsync(request.Id);
        if (product == null || product.IsDeleted)
        {
            return ApiResponse<ProductDto>.FailResponse("Product not found", 404);
        }

        product.ProductName = request.ProductName;
        product.ProductDescription = request.ProductDescription;
        product.Price = request.Price;
        product.DiscountPrice = request.DiscountPrice;
        product.StockQuantity = request.StockQuantity;
        product.ProductImage = request.ProductImage;
        product.Images = request.Images;
        product.Thumbnail = request.Thumbnail;
        product.SKU = request.SKU;
        product.CategoryId = request.CategoryId;
        product.IsActive = request.IsActive;
        product.IsFeatured = request.IsFeatured;
        product.Brand = request.Brand;
        product.Weight = request.Weight;
        product.Dimensions = request.Dimensions;
        product.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Repository<Domain.Entity.Product>().Update(product);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<ProductDto>(product);
        return ApiResponse<ProductDto>.SuccessResponse(dto, "Product updated successfully");
    }
}
