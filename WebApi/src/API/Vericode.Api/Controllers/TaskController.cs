using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Vericode.Api.Models.Request;
using Vericode.Api.Security.Attributes;
using Vericode.Domain.Entities;
using Vericode.Domain.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using Vericode.Api.Models.DTO;
using Vericode.Api.Models.Response;
using Microsoft.AspNetCore.Authorization;

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
            var taskEntityList = await _taskService.GetAll();
            var taskEntityListDTO = _mapper.Map<IEnumerable<TaskDTO>>(taskEntityList);
            return await Task.FromResult(Ok(new TaskListResponse(taskEntityListDTO)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskRequest taskRequest)
        {
            var taskEntity = _mapper.Map<TaskEntity>(taskRequest.Data);
            await _taskService.Enqueue(taskEntity);
            var response = _mapper.Map<TaskDTO>(taskEntity);
            return await Task.FromResult(Ok(new TaskResponse(response)));
        }
    }
}
