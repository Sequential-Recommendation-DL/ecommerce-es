using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.Commands;
using ShopappES.Domain.Enums;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Order.Handlers;

public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, ApiResponse>
{
    private readonly IShopappESUnitOfWork _unitOfWork;

    public CancelOrderCommandHandler(IShopappESUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Repository<Domain.Entity.Order>()
            .GetAll(o => o.Id == request.Id)
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(cancellationToken);

        if (order == null || order.IsDeleted)
        {
            return ApiResponse.FailResponse("Order not found", 404);
        }

        if (order.Status == OrderStatus.Cancelled)
        {
            return ApiResponse.FailResponse("Order is already cancelled", 400);
        }

        if (order.Status == OrderStatus.Shipped || order.Status == OrderStatus.Delivered)
        {
            return ApiResponse.FailResponse("Cannot cancel order that has already been shipped", 400);
        }

        foreach (var detail in order.OrderDetails)
        {
            var product = await _unitOfWork.Repository<Domain.Entity.Product>().GetByIdAsync(detail.ProductId);
            if (product != null)
            {
                product.StockQuantity += detail.Quantity;
                _unitOfWork.Repository<Domain.Entity.Product>().Update(product);
            }
        }

        order.Status = OrderStatus.Cancelled;
        order.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Repository<Domain.Entity.Order>().Update(order);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.SuccessResponse("Order cancelled successfully");
    }
}
