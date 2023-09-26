using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using Dapper;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Infra.Data.SQLRepository.Base;
using Vericode.Domain.Interfaces.Repositories.SQLServer;

namespace Vericode.Infra.Data.SQLRepository.Login
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
