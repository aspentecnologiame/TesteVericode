using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vericode.Infra.Data.RabbitMQRepository.RepositoryResolver;
using Vericode.Infra.Data.SQLRepository.RepositoryResolver;
using Vericode.Service.ServiceResolver;

namespace Vericode.Infra.CrossCutting
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterCrossCuttingDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServicesDependencies();
            services.RegisterSQLRepositoriesDependencies();
            services.RegisterRabbitMQRepositoriesDependencies();    
            return services;
        }
    }
}
