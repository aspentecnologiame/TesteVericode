using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vericode.Domain.Configurations;
using Vericode.Infra.CrossCutting;
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

            services.RegisterCrossCuttingDependencies(configuration);
            services.AddScoped<IRabbitConsumerJob, RabbitConsumerJob>();
            return services;
        }
    }
}
