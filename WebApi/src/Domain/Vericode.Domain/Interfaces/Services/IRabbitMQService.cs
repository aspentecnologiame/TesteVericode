using System.Threading.Tasks;
using Vericode.Domain.Interfaces.Services.Base;

namespace Vericode.Domain.Interfaces.Services
{
    public interface IRabbitMQService : IService
    {
        Task Publish<T>(T document);
    }
}
