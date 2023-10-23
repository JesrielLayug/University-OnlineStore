namespace OnlineEcommerce.Server.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public string Data { get; set; }
    }
}
