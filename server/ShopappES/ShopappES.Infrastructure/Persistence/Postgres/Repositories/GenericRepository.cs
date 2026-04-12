namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories;

using Domain.Common;
using Microsoft.EntityFrameworkCore;
using ShopappES.Domain.Intefaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ShopappESDbContext context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ShopappESDbContext context)
    {
        this.context = context;
        _dbSet = context.Set<T>();
    }

    public virtual IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.UtcNow;
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public virtual void SoftDelete(T entity)
    {
        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public virtual void HardDelete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null;
    }
}
