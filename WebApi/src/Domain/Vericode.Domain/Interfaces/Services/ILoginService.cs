using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services.Base;

namespace Vericode.Domain.Interfaces.Services
{
    public interface ILoginService : IService
    {
        Task<UserEntity> Login(UserEntity userEntity);
    }
}
