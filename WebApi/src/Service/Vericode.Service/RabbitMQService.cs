using Newtonsoft.Json;
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
            var message = JsonConvert.SerializeObject(document);
            await _rabbitMQRepository.Publish(message);
        }

        public async Task SatrtConsumeQueue<T>(Action<T> callBack)
        {
            _rabbitMQRepository.Subscribe((message) => 
            {
                var result = JsonConvert.DeserializeObject<T>(message);
                callBack(result); 
            });

            await Task.FromResult(Task.CompletedTask);
        }
    }
}
