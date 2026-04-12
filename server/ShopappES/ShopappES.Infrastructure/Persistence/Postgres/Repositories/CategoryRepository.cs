using System.Linq.Expressions;
using AutoMapper;
using ShopappES.Domain.Entity;
using ShopappES.Domain.Intefaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;

        public CategoryRepository(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context)); ;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public Task<Category> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
