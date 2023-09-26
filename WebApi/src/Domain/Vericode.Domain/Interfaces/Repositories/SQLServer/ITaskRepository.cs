using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Repositories.SQLServer.Base;

namespace Vericode.Domain.Interfaces.Repositories.SQLServer
{
    public interface ITaskRepository : IRepository
    {
        Task<bool> Insert(TaskEntity taskEntity);
    }
}
