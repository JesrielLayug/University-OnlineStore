using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public string ImageUrl { get; set; }
        public int VariantId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public int PriceModifier { get; set; }
        public string SKU { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; } = "COOP";
    }
}
