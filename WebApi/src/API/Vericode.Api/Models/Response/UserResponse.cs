using Vericode.Api.Models.DTO;

namespace Vericode.Api.Models.Response
{
    public class UserResponse : BaseResponse<object>
    {
        public UserResponse(object data) : base(data)
        {
        }
    }
}
