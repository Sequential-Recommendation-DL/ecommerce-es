using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Product.Commands;
using ShopappES.Domain.Intefaces;

namespace ShopappES.Application.Features.Product.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse>
{
    private readonly IShopappESUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IShopappESUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Repository<Domain.Entity.Product>().GetByIdAsync(request.Id);
        if (product == null || product.IsDeleted)
        {
            return ApiResponse.FailResponse("Product not found", 404);
        }

        _unitOfWork.Repository<Domain.Entity.Product>().SoftDelete(product);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.SuccessResponse("Product deleted successfully");
    }
}
