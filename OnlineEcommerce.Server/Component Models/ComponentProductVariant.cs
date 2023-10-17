using MudBlazor.Utilities;

namespace OnlineEcommerce.Server.Component_Models
{
    public class ComponentProductVariant
    {
        public string Size { get; set; }
        public MudColor Color { get; set; } = "#E53935";
        public int Stock { get; set; }
        public int PriceModifier { get; set; }
    }
}
