using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Entities.Base;
using Vericode.Domain.Interfaces.Repositories.SQLServer;
using Vericode.Infra.Data.SQLRepository.Base;
using Vericode.Infra.Data.SQLRepository.Login;

namespace Vericode.Infra.Data.SQLRepository.Task
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            using var connection = DatabaseConnection();
            return await connection.QueryAsync<TaskEntity>(TaskRepositoryCommands.GetAll);
        }

        public async Task<IEnumerable<TaskEntity>> Save(TaskEntity taskEntity)
        {
            using var connection = DatabaseConnection();
            return await connection.QueryAsync<TaskEntity>(TaskRepositoryCommands.Save, taskEntity);
        }
    }
}
