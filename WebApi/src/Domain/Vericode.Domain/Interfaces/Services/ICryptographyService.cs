using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vericode.Domain.Interfaces.Services.Base;

namespace Vericode.Domain.Interfaces.Services
{
    public interface ICryptographyService : IService
    {
        Task<string> Decrypt(string text);
        Task<string> Encrypt(string text);
    }
}
