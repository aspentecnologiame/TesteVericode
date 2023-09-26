using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services;
using Vericode.Worker.Jobs.interfaces;

namespace Vericode.Worker.Jobs
{
    public class RabbitConsumerJob : IRabbitConsumerJob
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly ITaskService _taskService;

        public RabbitConsumerJob(IRabbitMQService rabbitMQService, ITaskService taskService)
        {
            _rabbitMQService = rabbitMQService;
            _taskService = taskService;
        }

        public async Task SatrtConsumeQueue()
        {
            await _rabbitMQService.SatrtConsumeQueue<TaskEntity>(async (taskEntity) => { 
                taskEntity.Id = taskEntity.Id == Guid.Empty ? Guid.NewGuid() : taskEntity.Id;
                await _taskService.Insert(taskEntity);
            });
        }
    }
}
