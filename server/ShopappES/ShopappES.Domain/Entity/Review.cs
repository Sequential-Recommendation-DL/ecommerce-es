using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;

namespace ShopappES.Domain.Entity
{
    public class Review : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public string? Images { get; set; }
        public bool IsVerifiedPurchase { get; set; }
        public bool IsApproved { get; set; } = true;
        public int HelpfulCount { get; set; }
        public Review? ParentReview { get; set; }
        public Guid? ParentReviewId { get; set; }
        public ICollection<Review> Replies { get; set; } = new List<Review>();
    }
}
