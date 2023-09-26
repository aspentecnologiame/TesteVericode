using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Vericode.Api.Models.Request;
using Vericode.Api.Security.Attributes;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services;

namespace Vericode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeBearerAttribute(Roles = "allVerbs", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskRequest taskRequest)
        {
            var taskEntity = _mapper.Map<TaskEntity>(taskRequest.Data);
            await _taskService.Enqueue(taskEntity);
            return await Task.FromResult(Ok(taskRequest));
        }
    }
}
