using Vericode.Api.Models.DTO;

namespace Vericode.Api.Models.Response
{
    public class TaskListResponse : BaseResponse<IEnumerable<TaskDTO>>
    {
        public TaskListResponse(IEnumerable<TaskDTO> data) : base(data)
        {
        }
    }
}
