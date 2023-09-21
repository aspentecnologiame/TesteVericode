using Microsoft.AspNetCore.Authorization;

namespace Vericode.Api.Security.Requirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public RoleRequirement() { }

    }
}
