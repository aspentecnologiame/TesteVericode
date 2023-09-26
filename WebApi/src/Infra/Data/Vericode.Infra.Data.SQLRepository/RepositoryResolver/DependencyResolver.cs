using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Vericode.Domain.Interfaces.Repositories.SQLServer.Base;

namespace Vericode.Infra.Data.SQLRepository.RepositoryResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterSQLRepositoriesDependencies(this IServiceCollection services)
        {
            typeof(DependencyResolver).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IRepository).IsAssignableFrom(t))
                .ToList()
                .ForEach(t =>
                    t.GetInterfaces()
                        .Where(i => typeof(IRepository).IsAssignableFrom(i))
                        .ToList()
                        .ForEach(i => services.AddScoped(i, t))
                );

            return services;
        }
    }
}
