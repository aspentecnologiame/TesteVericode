using Vericode.Api.Models.DTO;

namespace Vericode.Api.Models.Request
{
    public class UserRequest : BaseRequest<UserDTO>
    {
        public UserRequest(UserDTO data) : base(data)
        {
        }
    }
}
