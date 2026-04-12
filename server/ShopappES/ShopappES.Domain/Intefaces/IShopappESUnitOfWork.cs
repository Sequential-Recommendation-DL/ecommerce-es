using ShopappES.Domain.Common;

namespace ShopappES.Domain.Intefaces
{
    public interface IShopappESUnitOfWork : IDisposable
    {

        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task CancelAsync();
    }

}
