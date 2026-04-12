using System.Linq.Expressions;
using AutoMapper;
using ShopappES.Domain.Entity;
using ShopappES.Domain.Common;
using ShopappES.Domain.Intefaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;

        public OrderRepository(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<Order?> AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
