using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Vericode.Domain.Configurations;
using Vericode.Domain.Interfaces.Repositories.RabbitMQ;
using System.Threading.Channels;

namespace Vericode.Infra.Data.RabbitMQRepository
{
    public class RabbitMQRepository : IRabbitMQRepository
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMQRepository(RabbitMQSettings rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings;
        }
        public async Task Publish(string message)
        {
            var factory = CreateAMPQConnectionFactory();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: _rabbitMQSettings.Exchange,
                                     routingKey: _rabbitMQSettings.QueueName,
                                     basicProperties: null,
                                     body: body);
            }

            await Task.FromResult(Task.CompletedTask);
        }

        public void Subscribe(Action<string> callBack)
        {
            var durable = true;
            var exclusive = false;
            var autoDelete = false;

            var factory = CreateAMPQConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(_rabbitMQSettings.QueueName, durable, exclusive, autoDelete, null);

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