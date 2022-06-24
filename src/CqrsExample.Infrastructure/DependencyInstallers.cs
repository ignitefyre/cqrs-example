using CqrsExample.Application;
using CqrsExample.Application.Carts;
using CqrsExample.Infrastructure.Carts;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsExample.Infrastructure;

public static class DependencyInstallers
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string initialCartId)
    {
        services.AddSingleton<ICartRepository>(new CartRepository(initialCartId));
        services.AddScoped<IEventRepository, EventRepository>();
        
        return services;
    }
}