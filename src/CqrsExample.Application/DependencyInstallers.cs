using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsExample.Application;

public static class DependencyInstallers
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}