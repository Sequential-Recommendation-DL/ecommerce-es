using AutoMapper;
using ShopappES.Domain.Entity;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{

    public class UserRepository 
    {
        private readonly ShopappESDbContext context;
        private readonly IMapper mapper;

        public UserRepository(ShopappESDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public User? FindById(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
