using ShopappES.Domain.Entity;
using ShopappES.Domain.Enums;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Application.Features.Shipping.DTOs;
using ShopappES.Application.Features.Review.DTOs;

namespace ShopappES.Application.Features.Auth.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Avatar { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; } = Gender.Other;
    public bool IsEmailVerified { get; set; }
    public bool IsPhoneVerified { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }
    public List<OrderDto>? Orders { get; set; }
    public List<AddressDto>? Addresses { get; set; }
    public List<ReviewDto>? Reviews { get; set; }
}
public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
}
