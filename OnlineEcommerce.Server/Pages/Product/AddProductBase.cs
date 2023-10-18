
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

        // Variant Section
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

        // Image Section
        public static string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mud-width-full mud-height-full z-10";
        public string DragClass = DefaultDragClass;
        public List<string> imageUrl = new List<string>();

        public void OnInputImageChanged(InputFileChangeEventArgs e)
        {
            ClearDragClass();
            var images = e.GetMultipleFiles();
            foreach (var image in images)
            {
                imageUrl.Add(image.Name);
            }
        }

        public void SetDragClass()
        {
            DragClass = $"{DefaultDragClass} mud-border-primary";
        }

        public void ClearDragClass()
        {
            DragClass = DefaultDragClass;
        }

    }
}

