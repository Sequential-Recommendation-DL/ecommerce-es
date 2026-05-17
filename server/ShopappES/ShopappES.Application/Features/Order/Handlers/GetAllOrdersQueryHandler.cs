using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Order.DTOs;
using ShopappES.Application.Features.Order.Queries;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Order.Handlers;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ApiResponse<List<OrderDto>>>
{
    private readonly IShopappESUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IShopappESUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Repository<Domain.Entity.Order>()
            .GetAll(o => !o.IsDeleted)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                    .ThenInclude(p => p.Category)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<OrderDto>>(orders);
        return ApiResponse<List<OrderDto>>.SuccessResponse(dtos, "Orders retrieved successfully");
    }
}
