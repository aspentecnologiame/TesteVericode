using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vericode.Worker.Jobs.interfaces
{
    public interface IRabbitConsumerJob
    {
        Task SatrtConsumeQueue();
    }
}
