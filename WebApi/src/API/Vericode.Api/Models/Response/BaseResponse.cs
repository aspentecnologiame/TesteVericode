namespace Vericode.Api.Models.Response
{
    public class BaseResponse<T> where T : class
    {
        public List<string> Message { get; set; }
        public T Data { get; set; }

        public BaseResponse(T data)
        {
            this.Message = new List<string>();
            this.Data = data;
        }
    }
}
