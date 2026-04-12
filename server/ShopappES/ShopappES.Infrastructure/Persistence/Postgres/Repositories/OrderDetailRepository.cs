using System.Linq.Expressions;
using AutoMapper;
using ShopappES.Domain.Entity;
using ShopappES.Domain.Intefaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class OrderDetailRepository : IGenericRepository<OrderDetail>
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;

        public OrderDetailRepository(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public Task<OrderDetail> AddAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
