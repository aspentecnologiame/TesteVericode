using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Interfaces.Services;
using Vericode.Worker.Jobs.interfaces;

namespace Vericode.Worker.Jobs
{
    public class RabbitConsumerJob : IRabbitConsumerJob
    {
        private readonly IRabbitMQService _rabbitMQService;

        public RabbitConsumerJob(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public async Task SatrtConsumeQueue()
        {
            await _rabbitMQService.SatrtConsumeQueue();
        }
    }
}
