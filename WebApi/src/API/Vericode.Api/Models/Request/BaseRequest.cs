namespace Vericode.Api.Models.Request
{
    public abstract class BaseRequest<T> where T : class
    {
        public T Data { get; set; }

        public BaseRequest(T data)
        {
            this.Data = data;
        }
    }
}
