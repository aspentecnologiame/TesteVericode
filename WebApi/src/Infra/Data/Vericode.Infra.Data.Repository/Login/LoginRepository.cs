using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using Dapper;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Repositories;
using Vericode.Infra.Data.Repository.Base;

namespace Vericode.Infra.Data.Repository.Login
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<UserEntity> GetByLoginPassword(UserEntity userEntity)
        {
            using var connection = DatabaseConnection();
            return await connection.QueryFirstOrDefaultAsync<UserEntity>(LoginRepositoryCommands.GetByLoginPassword, userEntity);
        }
    }
}
