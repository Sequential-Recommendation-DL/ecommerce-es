using ShopappES.Application.Repositories;

namespace ShopappES.Application.UnitOfWork
{
    public interface IShopappESUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task CancelAsync();
    }
}

