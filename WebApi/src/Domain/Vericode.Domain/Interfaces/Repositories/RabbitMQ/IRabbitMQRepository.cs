using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Interfaces.Repositories.RabbitMQ.Base;

namespace Vericode.Domain.Interfaces.Repositories.RabbitMQ
{
    public interface IRabbitMQRepository : IRepository
    {
        Task Publish<T>(T document);
        void Subscribe(Action<string> callBack);
    }
}
