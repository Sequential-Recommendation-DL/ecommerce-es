using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;
using ShopappES.Domain.Enums;

namespace ShopappES.Domain.Entity
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public CouponType Type { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public int? MaxUsagePerUser { get; set; }
        public CouponScope Scope { get; set; } = CouponScope.All;
        public int? ScopeCategoryId { get; set; }
        public int? ScopeProductId { get; set; }
        public CouponUsageType UsageType { get; set; } = CouponUsageType.AllOrders;
        public bool IsActive { get; set; } = true;
        public bool IsFirstOrderOnly { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
