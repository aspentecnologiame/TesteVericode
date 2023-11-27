using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vericode.Domain.Interfaces.Services.Base;
using Vericode.Infra.Data.RabbitMQRepository.RepositoryResolver;
using Vericode.Infra.Data.SQLRepository.RepositoryResolver;
using Vericode.Service.ServiceResolver;
using Vericode.Worker.WorkerResolver;

namespace Vericode.Infra.CrossCutting
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterCrossCuttingDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServicesDependencies();
            services.RegisterSQLRepositoriesDependencies();
            services.RegisterRabbitMQRepositoriesDependencies();
            services.RegisterWorkerDependencies();

            return services;
        }
    }
}
