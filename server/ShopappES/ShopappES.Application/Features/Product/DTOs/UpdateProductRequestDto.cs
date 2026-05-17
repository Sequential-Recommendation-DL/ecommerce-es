namespace ShopappES.Application.Features.Product.DTOs;

public class UpdateProductRequestDto
{
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
