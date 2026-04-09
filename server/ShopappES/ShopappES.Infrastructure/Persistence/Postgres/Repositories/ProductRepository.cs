using AutoMapper;
using ShopappES.Application.Repositories;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class ProductRepository(ShopappESDbContext context, IMapper mapper) : IProductRepository
    {

        private readonly ShopappESDbContext contextt;
        private readonly IMapper mapper;
    }
}
