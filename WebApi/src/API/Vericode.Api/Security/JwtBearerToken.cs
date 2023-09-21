using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vericode.Domain.Configurations;
using Vericode.Domain.Entities;

namespace Vericode.Api.Security
{
    public class JwtBearerToken
    {
        private readonly AuthenticationSettings _authenticationSettings;
        private const string _role = "allVerbs";
        public JwtBearerToken(AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateToken(UserEntity userEntity)
        {
            var claims = new[]
            {
                new Claim("userId", userEntity.Id.ToString()),
                new Claim("login", userEntity.Login),
                new Claim(ClaimTypes.Role, _role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.SecretKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                claims: claims,
                signingCredentials: credential,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _authenticationSettings.Issuer,
                audience: _authenticationSettings.Audience
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
