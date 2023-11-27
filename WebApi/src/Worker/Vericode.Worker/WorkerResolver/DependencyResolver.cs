using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vericode.Domain.Configurations;
using Vericode.Worker.Jobs;
using Vericode.Worker.Jobs.interfaces;

namespace Vericode.Worker.WorkerResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterWorkerDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitConsumerJob, RabbitConsumerJob>();
            return services;
        }
    }
}
