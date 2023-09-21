using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vericode.Domain.Interfaces.Repositories.Base;

namespace Vericode.Infra.Data.Repository.RepositoryResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterRepositoriesDependencies(this IServiceCollection services)
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
