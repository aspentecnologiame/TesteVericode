using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Vericode.Domain.Interfaces.Services.Base;

namespace Vericode.Service.ServiceResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterServicesDependencies(this IServiceCollection services)
        {
            typeof(DependencyResolver).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IService).IsAssignableFrom(t))
                .ToList()
                .ForEach(t =>
                    t.GetInterfaces()
                        .Where(i => typeof(IService).IsAssignableFrom(i))
                        .ToList()
                        .ForEach(i => services.AddSingleton(i, t))
                );

            return services;
        }
    }
}
