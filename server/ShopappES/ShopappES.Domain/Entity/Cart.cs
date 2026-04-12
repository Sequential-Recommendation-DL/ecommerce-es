using ShopappES.Domain.Common;

namespace ShopappES.Domain.Entity
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; set; }
        public int TotalItems { get; set; }
    }
}
