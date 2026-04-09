using AutoMapper;
using ShopappES.Application.Repositories;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
    }
}
