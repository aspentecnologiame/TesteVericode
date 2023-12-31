﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using Vericode.Worker.WorkerResolver;
using Vericode.Worker.Jobs.interfaces;
using System.Threading;

namespace Vericode.Worker.WorkerService
{
    public class Worker : BackgroundService
    {
        private static IConfiguration? Configuration { get; set; }
        public static ServiceProvider? ServiceProvider { get; set; }

        private readonly ILogger<Worker> _logger;
        private readonly IRabbitConsumerJob _rabbitConsumerJob;

        public Worker(ILogger<Worker> logger, IRabbitConsumerJob rabbitConsumerJob, IConfiguration configuration)
        {
            _logger = logger;
            _rabbitConsumerJob = rabbitConsumerJob;
            Configuration = configuration;
        } 

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitConsumerJob.SatrtConsumeQueue();
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando o Rabbit Consumer");
            await base.StopAsync(cancellationToken);
        }
    }
}
