using AutoMapper;
using ShopappES.Application.Repositories;
using ShopappES.Domain;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories
{

    public class UserRepository(ShopappESDbContext context, IMapper mapper) : IUserRepository
    {
        private readonly ShopappESDbContext context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public User FindById(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
