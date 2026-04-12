using System.Linq.Expressions;
using AutoMapper;
using ShopappES.Domain.Entity;
using ShopappES.Domain.Common;
using ShopappES.Domain.Intefaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<Product> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
