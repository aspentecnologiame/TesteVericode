using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Interfaces.Repositories.RabbitMQ;
using Vericode.Domain.Interfaces.Services;

namespace Vericode.Service
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IRabbitMQRepository _rabbitMQRepository;

        public RabbitMQService(IRabbitMQRepository rabbitMQRepository)
        {
            _rabbitMQRepository = rabbitMQRepository;
        }

        public async Task Publish<T>(T document)
        {
            await _rabbitMQRepository.Publish(document);
        }

        public async Task SatrtConsumeQueue()
        {
            _rabbitMQRepository.Subscribe(message => this.HanldeMessage(message));
            await Task.FromResult(Task.CompletedTask);
        }

        public void HanldeMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
