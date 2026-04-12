using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using ShopappES.Domain.Common;
using ShopappES.Domain.Intefaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;
namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class ShopappESUnitOfWork : IShopappESUnitOfWork
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;
        private IDbContextTransaction? _currentTransaction;

        public ShopappESUnitOfWork(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(context);
        }
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
                return;
            _currentTransaction = await context.Database.BeginTransactionAsync();

        }

        public async Task CancelAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();

                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync();
                }
            }
            catch
            {
                await CancelAsync();
                throw;
            }
            finally
            {
                _currentTransaction?.Dispose();
                _currentTransaction = null;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
