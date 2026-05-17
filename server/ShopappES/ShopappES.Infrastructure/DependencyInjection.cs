using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopappES.Domain.Intefaces;
using ShopappES.Application.Features.Auth.Interfaces;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;
using ShopappES.Infrastructure.Persistence.Postgres.Repositories;
using Marten;

namespace ShopappES.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");
            services.AddDbContext<ShopappESDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddScoped<IShopappESUnitOfWork, ShopappESUnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMarten(opts =>
            {
                opts.Connection(configuration.GetConnectionString("Postgres")!);
            }).UseLightweightSessions();
            return services;

        }
    }
}
