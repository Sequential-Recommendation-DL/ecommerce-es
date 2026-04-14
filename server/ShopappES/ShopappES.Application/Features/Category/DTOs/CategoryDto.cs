using ShopappES.Domain.Entity;

namespace ShopappES.Application.Features.Category.DTOs;

using ShopappES.Application.Features.Product.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? CategoryDescription { get; set; }
    public string? CategoryImage { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
    public List<ProductDto>? Products { get; set; }
}
