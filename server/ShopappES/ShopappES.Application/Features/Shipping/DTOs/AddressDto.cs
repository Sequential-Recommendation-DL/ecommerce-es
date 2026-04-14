using ShopappES.Application.Features.Auth.DTOs;
using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Shipping.DTOs;

public class AddressDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public string ReceiverName { get; set; } = string.Empty;
    public string? ReceiverPhone { get; set; }
    public string AddressLine { get; set; } = string.Empty;
    public string? Ward { get; set; }
    public string? District { get; set; }
    public string? Province { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDefaultBilling { get; set; }
    public bool IsDefaultShipping { get; set; }
    public AddressType AddressType { get; set; } = AddressType.Other;
    public List<OrderDto>? Orders { get; set; }
}

public enum AddressType
{
    Home,
    Office,
    Other
}
