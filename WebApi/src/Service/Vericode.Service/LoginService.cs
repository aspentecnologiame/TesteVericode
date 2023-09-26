using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Repositories.SQLServer;
using Vericode.Domain.Interfaces.Services;

namespace Vericode.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ICryptographyService _cryptographyService;
        public LoginService(ILoginRepository loginRepository, ICryptographyService cryptographyService)
        {
            _loginRepository = loginRepository;
            _cryptographyService = cryptographyService;

        }

        public async Task<UserEntity> Login(UserEntity userEntity)
        {
            var user = new UserEntity { Login = userEntity.Login, Password = await _cryptographyService.Encrypt(userEntity.Password) };
            var userRepository = await _loginRepository.GetByLoginPassword(user);

            return userRepository;
        }
    }
}
