namespace OnlineEcommerce.Server.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Stock { get; set; }
        public int PriceModifier { get; set; } = 0;
        public string SKU { get; set; }
    }
}
