using AutoMapper;
using ShopappES.Application.Repositories;
using ShopappES.Domain;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class CategoryRepository(ShopappESDbContext context, IMapper mapper) : ICategoryRepository
    {
        private readonly ShopappESDbContext context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


        public Category FindById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
