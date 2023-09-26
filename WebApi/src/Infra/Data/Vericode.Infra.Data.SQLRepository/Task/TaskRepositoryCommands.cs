using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Infra.Data.SQLRepository.Task
{
    public static class TaskRepositoryCommands
    {
        public const string Insert = @"INSERT INTO [TbTask] VALUES (@Id, @Description, @Status, @Date, GETDATE(), NULL)";
    }
}
