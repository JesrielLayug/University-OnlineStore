
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Utilities;
using OnlineEcommerce.Server.Component_Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Utilities;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class AddProductBase : ComponentBase
    {
        public ComponentProduct product = new ComponentProduct();
        public ComponentProductVariant variant = new ComponentProductVariant();
        public List<ComponentProductVariant> Variants;

        public AddProductBase()
        {
            LoadsVariants().Wait();
        }

        public void AddVariant()
        {
            StaticListProductVariant.AddVariant(new ComponentProductVariant
            {
                Color = variant.Color,
                Size = variant.Size,
                PriceModifier = variant.PriceModifier,
                Stock = variant.Stock,
            });
        }

        public void RemoveVariant(MudChip chip)
        {
            string chipText = chip.Text;
            ComponentProductVariant variantToRemove = Variants.FirstOrDefault(v => v.Size == chipText || v.Color == chipText);

            if (variantToRemove != null)
            {
                StaticListProductVariant.RemoveVariant(variantToRemove);
            }
        }

        public async Task LoadsVariants()
        {
            Variants = StaticListProductVariant.GetVariants();
        }

    }
}

