using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services.Base;

namespace Vericode.Domain.Interfaces.Services
{
    public interface ITaskService : IService
    {
        Task<IEnumerable<TaskEntity>> GetAll();
        Task Enqueue(TaskEntity taskEntity);
        Task<IEnumerable<TaskEntity>> Save(TaskEntity taskEntity);
    }
}
