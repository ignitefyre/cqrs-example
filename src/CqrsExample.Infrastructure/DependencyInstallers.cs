using CqrsExample.Application.Carts;
using CqrsExample.Infrastructure.Carts;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsExample.Infrastructure;

public static class DependencyInstallers
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ICartRepository, CartRepository>();
        
        return services;
    }
}