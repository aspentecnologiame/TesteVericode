using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vericode.Domain.Configurations;
using Vericode.Domain.Interfaces.Services.Base;
using Vericode.Infra.Data.RabbitMQRepository.RepositoryResolver;
using Vericode.Service.ServiceResolver;
using Vericode.Worker.Jobs;
using Vericode.Worker.Jobs.interfaces;

namespace Vericode.Worker.WorkerResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterWorkerDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQSettings = configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();
            services.AddSingleton(rabbitMQSettings);

            services.RegisterServicesDependencies();
            services.RegisterRabbitMQRepositoriesDependencies();
            services.AddScoped<IRabbitConsumerJob, RabbitConsumerJob>();
            return services;
        }
    }
}
