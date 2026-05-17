using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.Commands;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Domain.Entity;
using ShopappES.Domain.Enums;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Order.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ApiResponse<OrderDto>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Items == null || request.Items.Count == 0)
        {
            return ApiResponse<OrderDto>.FailResponse("Order must contain at least one item", 400);
        }

        decimal totalAmount = 0;
        var orderDetails = new List<Domain.Entity.OrderDetail>();

        foreach (var item in request.Items)
        {
            var product = await _unitOfWork.Repository<Domain.Entity.Product>().GetByIdAsync(item.ProductId);
            if (product == null || product.IsDeleted)
            {
                return ApiResponse<OrderDto>.FailResponse($"Product {item.ProductId} not found", 404);
            }

            if (product.StockQuantity < item.Quantity)
            {
                return ApiResponse<OrderDto>.FailResponse($"Insufficient stock for product {product.ProductName}", 400);
            }

            product.StockQuantity -= item.Quantity;
            _unitOfWork.Repository<Domain.Entity.Product>().Update(product);

            var detail = new Domain.Entity.OrderDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price,
                DiscountPrice = product.DiscountPrice,
                TotalPrice = (product.DiscountPrice ?? product.Price) * item.Quantity
            };

            totalAmount += detail.TotalPrice;
            orderDetails.Add(detail);
        }

        var order = new Domain.Entity.Order
        {
            OrderCode = $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid():N}"[..20],
            UserId = request.UserId,
            Status = OrderStatus.Pending,
            TotalAmount = totalAmount,
            ShippingFee = 0,
            FinalAmount = totalAmount,
            Note = request.Note,
            AddressId = request.AddressId,
            CouponId = request.CouponId,
            OrderDetails = orderDetails
        };

        await _unitOfWork.Repository<Domain.Entity.Order>().AddAsync(order);
        await _unitOfWork.SaveChangesAsync();

        var dto = await LoadOrderDto(order.Id);
        return ApiResponse<OrderDto>.SuccessResponse(dto, "Order created successfully", 201);
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
