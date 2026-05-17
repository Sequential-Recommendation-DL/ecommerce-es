using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.DTOs;

namespace ShopappES.Application.Features.Product.Commands;

public class UpdateProductCommand : IRequest<ApiResponse<ProductDto>>
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductDescription { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int StockQuantity { get; set; }
    public string? ProductImage { get; set; }
    public string? Images { get; set; }
    public string? Thumbnail { get; set; }
    public string? SKU { get; set; }
    public Guid CategoryId { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; }
    public string? Brand { get; set; }
    public double? Weight { get; set; }
    public string? Dimensions { get; set; }
}
