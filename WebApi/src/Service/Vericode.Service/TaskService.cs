using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services;

namespace Vericode.Service
{
    public class TaskService : ITaskService
    {
        private readonly IRabbitMQService _rabbitmqService;

        public TaskService(IRabbitMQService rabbitmqService)
        {
            _rabbitmqService = rabbitmqService;
        }

        public async Task Save(TaskEntity taskEntity)
        {
            await _rabbitmqService.Publish(taskEntity);
        }
    }
}
