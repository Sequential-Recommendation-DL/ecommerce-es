using System.Linq.Expressions;
using ShopappES.Domain.Common;

namespace ShopappES.Domain.Intefaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void SoftDelete(T entity);
        void HardDelete(T entity);
        Task<bool> ExistsAsync(Guid id);
    }
}
