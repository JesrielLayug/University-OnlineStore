namespace OnlineEcommerce.Server.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Stock { get; set; }
        public int PriceModifier { get; set; }
    }
}
