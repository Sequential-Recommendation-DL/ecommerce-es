using ShopappES.Domain.Enums;

namespace ShopappES.Application.Features.Order.DTOs;

public class UpdateOrderStatusRequestDto
{
    public OrderStatus Status { get; set; }
}
