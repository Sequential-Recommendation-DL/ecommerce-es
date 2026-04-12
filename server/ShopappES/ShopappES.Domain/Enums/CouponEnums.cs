namespace ShopappES.Domain.Enums;

public enum CouponType
{
    Percentage,
    FixedAmount,
    FreeShipping
}

public enum CouponScope
{
    All,
    Category,
    Product
}

public enum CouponUsageType
{
    FirstOrder,
    AllOrders,
    SpecificUsers
}