using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vericode.Api.Models.DTO;
using Vericode.Api.Models.Request;
using Vericode.Api.Models.Response;
using Vericode.Api.Security;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services;

namespace Vericode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly JwtBearerToken _jwtBearerToken;
        public LoginController(IMapper mapper, ILoginService loginService, JwtBearerToken jwtBearerToken)
        {
            _loginService = loginService;
            _mapper = mapper;
            _jwtBearerToken = jwtBearerToken;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(UserRequest userRequest)
        {
            string token = string.Empty;
            var userEntity = _mapper.Map<UserEntity>(userRequest.Data);
            var userRepository = await _loginService.Login(userEntity);

            if (userRepository != null) token = _jwtBearerToken.GenerateToken(userRepository);

            var response = new UserResponse(new { Token = token });

            return await Task.FromResult(Ok(response));
        }
    }
}
