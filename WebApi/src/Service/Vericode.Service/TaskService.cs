using System.Collections.Generic;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Repositories.SQLServer;
using Vericode.Domain.Interfaces.Services;

namespace Vericode.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IRabbitMQService _rabbitmqService;
        

        public TaskService(IRabbitMQService rabbitmqService, ITaskRepository taskRepository)
        {
            _rabbitmqService = rabbitmqService;
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<TaskEntity>> GetAll() => await _taskRepository.GetAll();

        public async Task Enqueue(TaskEntity taskEntity) => await _rabbitmqService.Publish(taskEntity);

        public async Task<IEnumerable<TaskEntity>> Save(TaskEntity taskEntity)
        {
            var result  = await _taskRepository.Save(taskEntity);
            return result;
        }
    }
}
