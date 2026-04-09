using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using ShopappES.Application.Repositories;
using ShopappES.Application.UnitOfWork;
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

            UserRepository = new UserRepository(context, mapper);
            OrderRepository = new OrderRepository(context, mapper);
            OrderDetailRepository = new OrderDetailRepository(context, mapper);
            ProductRepository = new ProductRepository(context, mapper);
            CategoryRepository = new CategoryRepository(context, mapper);
        }

        public IUserRepository UserRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IProductRepository ProductRepository { get; }

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
                // 1. Lưu toàn bộ thay đổi của EF Core xuống DB
                await context.SaveChangesAsync();

                // 2. Nếu có transaction đang mở thì commit nó
                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync();
                }
            }
            catch
            {
                // Nếu lưu lỗi thì phải hủy bỏ transaction ngay
                await CancelAsync();
                throw; // Ném lỗi ra ngoài để tầng Application xử lý
            }
            finally
            {
                // Dọn dẹp transaction sau khi xong
                _currentTransaction?.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
