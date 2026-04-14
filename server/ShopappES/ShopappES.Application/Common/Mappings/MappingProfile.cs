using AutoMapper;
using ShopappES.Application.Features.Auth.DTOs;
using ShopappES.Application.Features.Category.DTOs;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Application.Features.Payment.DTOs;
using ShopappES.Application.Features.Product.DTOs;
using ShopappES.Application.Features.Review.DTOs;
using ShopappES.Application.Features.Shipping.DTOs;
using ShopappES.Domain.Entity;

namespace ShopappES.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserDto>().ReverseMap();

            // Category mappings
            CreateMap<Category, CategoryDto>().ReverseMap();

            // Product mappings
            CreateMap<Product, ProductDto>().ReverseMap();

            // Order mappings
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            // Payment mappings
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();

            // Shipping mappings
            CreateMap<Shipping, ShippingDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

            // Review mappings
            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}
