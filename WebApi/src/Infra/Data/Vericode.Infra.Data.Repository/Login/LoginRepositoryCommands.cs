using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Infra.Data.Repository.Login
{
    public static class LoginRepositoryCommands
    {
        public const string GetByLoginPassword = @"SELECT [Id], [Login], [Email] FROM Tb_User WHERE [Login] = @Login AND [Password] = @Password";
    }
}
