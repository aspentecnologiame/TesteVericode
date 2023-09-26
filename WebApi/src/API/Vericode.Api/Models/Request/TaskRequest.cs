using Vericode.Api.Models.DTO;

namespace Vericode.Api.Models.Request
{
    public class TaskRequest : BaseRequest<TaskDTO>
    {
        public TaskRequest(TaskDTO data) : base(data)
        {
        }
    }
}
