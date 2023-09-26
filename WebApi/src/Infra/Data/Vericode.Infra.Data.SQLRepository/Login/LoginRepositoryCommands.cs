using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Infra.Data.SQLRepository.Login
{
    public static class LoginRepositoryCommands
    {
        public const string GetByLoginPassword = @"SELECT [Id], [Login], [Email] FROM [TbUser] WHERE [Login] = @Login AND [Password] = @Password";
    }
}
