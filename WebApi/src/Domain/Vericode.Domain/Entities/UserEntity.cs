using System;
using Vericode.Domain.Entities.Base;

namespace Vericode.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
