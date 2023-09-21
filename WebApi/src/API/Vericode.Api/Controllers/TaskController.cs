using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Vericode.Api.Security.Attributes;

namespace Vericode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeBearerAttribute(Roles = "allVerbs", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok());
        }
    }
}
