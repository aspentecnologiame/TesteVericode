using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Vericode.Domain.Configurations;
using Newtonsoft.Json;
using Vericode.Domain.Interfaces.Repositories.RabbitMQ;

namespace Vericode.Infra.Data.RabbitMQRepository
{
    public class RabbitMQRepository : IRabbitMQRepository
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMQRepository(RabbitMQSettings rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings;
        }
        public async Task Publish<T>(T document)
        {
            var factory = CreateAMPQConnectionFactory();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var message = JsonConvert.SerializeObject(document);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: _rabbitMQSettings.Exchange,
                                     routingKey: _rabbitMQSettings.QueueName,
                                     basicProperties: null,
                                     body: body);
            }

            await Task.FromResult(document);
        }

        public void Subscribe(Action<string> callBack)
        {
            var factory = CreateHostConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueBind(queue: _rabbitMQSettings.QueueName,
                                  exchange: _rabbitMQSettings.Exchange,
                                  routingKey: _rabbitMQSettings.RoutingKey);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                callBack(message);
            };

            channel.BasicConsume(queue: _rabbitMQSettings.QueueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private ConnectionFactory CreateAMPQConnectionFactory() => new() { Uri = new Uri(_rabbitMQSettings.Uri) };

        private ConnectionFactory CreateHostConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = _rabbitMQSettings.HostName,
                UserName = _rabbitMQSettings.UserName,
                Password = _rabbitMQSettings.Password
            };
        }
    }
}