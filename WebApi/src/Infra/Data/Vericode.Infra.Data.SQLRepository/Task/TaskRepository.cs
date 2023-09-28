using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
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

        public async Task<bool> Save(TaskEntity taskEntity)
        {
            using var connection = DatabaseConnection();
            return await connection.ExecuteAsync(TaskRepositoryCommands.Save, taskEntity) > 0;
        }
    }
}
