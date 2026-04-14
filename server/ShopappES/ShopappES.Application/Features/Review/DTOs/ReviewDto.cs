using ShopappES.Domain.Entity;
using ShopappES.Application.Features.Product.DTOs;

namespace ShopappES.Application.Features.Review.DTOs;

public class ReviewDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public string? Images { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public bool IsApproved { get; set; } = true;
    public int HelpfulCount { get; set; }
    public Guid? ParentReviewId { get; set; }
    public ReviewDto? ParentReview { get; set; }
    public List<ReviewDto>? Replies { get; set; }
}
