using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vericode.Infra.Data.Repository.Base
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection DatabaseConnection() => new SqlConnection(_configuration.GetConnectionString("Vericode"));
    }
}
