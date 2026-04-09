using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopappES.Application.UnitOfWork;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;
using ShopappES.Infrastructure.Persistence.Postgres.MapperProfile;
using ShopappES.Infrastructure.Persistence.Postgres.Repositories;

namespace ShopappES.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");
        services.AddDbContext<ShopappESDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddAutoMapper(cfg => { }, typeof(MapperProfile));
        services.AddScoped<IShopappESUnitOfWork, ShopappESUnitOfWork>();

        return services;
    }
}
