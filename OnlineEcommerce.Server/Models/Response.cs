namespace OnlineEcommerce.Server.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
        public T? Data { get; set; }
    }
}
