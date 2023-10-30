using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Utilities
{
    public static class StaticProduct
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Description { get; set; }
        public static int BasePrice { get; set; }
        public static string ImageUrl { get; set; }
        public static List<DTO_ProductImage> Images { get; set; }
        public static List<DTO_ProductVariant> Variants { get; set; }
        public static string SKU { get; set; }
        public static string OrganizationName { get; set; } = "COOP";
    }
}
