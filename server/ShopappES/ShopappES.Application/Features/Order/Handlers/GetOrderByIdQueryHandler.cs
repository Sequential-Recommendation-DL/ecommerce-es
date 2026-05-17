using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Application.Features.Order.Queries;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Order.Handlers;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderDto>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entity.Order> query = _unitOfWork.Repository<Domain.Entity.Order>()
            .GetAll(o => o.Id == request.Id && !o.IsDeleted)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                    .ThenInclude(p => p.Category);

        if (request.UserId.HasValue)
        {
            query = query.Where(o => o.UserId == request.UserId.Value);
        }

        var order = await query.FirstOrDefaultAsync(cancellationToken);

        if (order == null)
        {
            return ApiResponse<OrderDto>.FailResponse("Order not found", 404);
        }

        var dto = _mapper.Map<OrderDto>(order);
        return ApiResponse<OrderDto>.SuccessResponse(dto, "Order retrieved successfully");
    }
}
