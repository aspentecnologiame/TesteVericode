﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services;
using Vericode.Worker.Hubs;
using Vericode.Worker.Jobs.interfaces;

namespace Vericode.Worker.Jobs
{
    public class RabbitConsumerJob : IRabbitConsumerJob
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly ITaskService _taskService;
        private readonly IHubContext<TaskHub> _taskHub;

        public RabbitConsumerJob(IRabbitMQService rabbitMQService, ITaskService taskService, IHubContext<TaskHub> taskHub)
        {
            _rabbitMQService = rabbitMQService;
            _taskService = taskService;
            _taskHub = taskHub;
        }

        public async Task SatrtConsumeQueue()
        {
            await _rabbitMQService.SatrtConsumeQueue<TaskEntity>(async (taskEntity) => { 
                taskEntity.Id = taskEntity.Id == Guid.Empty ? Guid.NewGuid() : taskEntity.Id;
                var result = await _taskService.Save(taskEntity);
                await _taskHub.Clients.All.SendAsync("TransferTaskData", result);
            });
        }
    }
}
