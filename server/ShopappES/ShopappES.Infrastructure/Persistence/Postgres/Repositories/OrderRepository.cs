using AutoMapper;
using ShopappES.Application.Repositories;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class OrderRepository(ShopappESDbContext context, IMapper mapper) : IOrderRepository
    {
        private readonly ShopappESDbContext contextt;
        private readonly IMapper mapper;
    }
}
