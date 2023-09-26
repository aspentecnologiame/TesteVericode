using Vericode.Api.Models.DTO;

namespace Vericode.Api.Models.Response
{
    public class TaskResponse : BaseResponse<TaskDTO>
    {
        public TaskResponse(TaskDTO data) : base(data)
        {
        }
    }
}
