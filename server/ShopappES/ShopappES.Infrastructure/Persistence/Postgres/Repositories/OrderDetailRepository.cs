using AutoMapper;
using ShopappES.Application.Repositories;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{
    public class OrderDetailRepository(ShopappESDbContext context, IMapper mapper) : IOrderDetailRepository
    {
        private readonly ShopappESDbContext context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    }
}
