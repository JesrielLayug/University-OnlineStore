﻿using MudBlazor.Utilities;

namespace OnlineEcommerce.Server.Component_Models
{
    public class ComponentProductVariant
    {
        public int Id { get; set; }
        public string Size { get; set; } = string.Empty;
        public MudColor Color { get; set; } = "#E53935";
        public int Stock { get; set; }
        public int PriceModifier { get; set; }
        public string SKU { get; set; }
    }
}
