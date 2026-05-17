using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopappES.Application.Common.Behaviors;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.Interfaces;

namespace ShopappES.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
