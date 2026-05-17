using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.Commands;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Domain.Enums;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Order.Handlers;

public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, ApiResponse<OrderDto>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateOrderStatusCommandHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<OrderDto>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Repository<Domain.Entity.Order>().GetByIdAsync(request.Id);
        if (order == null || order.IsDeleted)
        {
            return ApiResponse<OrderDto>.FailResponse("Order not found", 404);
        }

        if (order.Status == OrderStatus.Cancelled || order.Status == OrderStatus.Delivered)
        {
            return ApiResponse<OrderDto>.FailResponse($"Cannot update status of a {order.Status.ToString().ToLower()} order", 400);
        }

        order.Status = request.Status;
        order.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Repository<Domain.Entity.Order>().Update(order);
        await _unitOfWork.SaveChangesAsync();

        var dto = await LoadOrderDto(order.Id);
        return ApiResponse<OrderDto>.SuccessResponse(dto, "Order status updated successfully");
    }

    private async Task<OrderDto> LoadOrderDto(Guid orderId)
    {
        var order = await _unitOfWork.Repository<Domain.Entity.Order>()
            .GetAll(o => o.Id == orderId)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                    .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync();

        return _mapper.Map<OrderDto>(order);
    }
}
