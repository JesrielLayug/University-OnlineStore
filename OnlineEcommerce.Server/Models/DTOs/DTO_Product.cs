using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public string ImageUrl { get; set; }
        public List<DTO_ProductImage> Images { get; set; }
        public List<DTO_ProductVariant> Variants { get; set; }
        public string SKU { get; set; }
        public string OrganizationName { get; set; } = "COOP";

    }
}
