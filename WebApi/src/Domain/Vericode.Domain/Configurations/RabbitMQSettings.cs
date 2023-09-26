using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Domain.Configurations
{
    public class RabbitMQSettings
    {
        public string Uri { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string QueueName { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
