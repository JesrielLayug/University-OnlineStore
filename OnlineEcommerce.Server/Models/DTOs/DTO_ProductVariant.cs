using MudBlazor.Utilities;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_ProductVariant
    {
        public int Id { get; set; }
        public string? Size { get; set; } = string.Empty;
        public MudColor Color { get; set; } = "#ffffffff";
        public int Stock { get; set; }
        public int PriceModifier { get; set; }
        public string SKU { get; set; }
    }
}
