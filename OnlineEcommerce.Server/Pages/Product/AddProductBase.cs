
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Utilities;
using OnlineEcommerce.Server.Component_Models;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;
using OnlineEcommerce.Server.Utilities;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class AddProductBase : ComponentBase
    {
        [Inject]
        IProductService ProductService { get; set; }

        [Inject]
        ISnackbar Snackbar { get; set; }

        public List<ComponentProductImages> Images = new List<ComponentProductImages>();
        public List<ComponentProductVariant> Variants = new List<ComponentProductVariant>();

        public ComponentProductDetail productDetail = new ComponentProductDetail();
        public ComponentProductVariant variant = new ComponentProductVariant();
        public ComponentProductImages productImage;
      

        public bool _processing = false;

        public AddProductBase()
        {
            LoadsComponents().Wait();
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

        public void RemoveChip(MudChip chip)
        {
            string chipText = chip.Text;
            ComponentProductVariant variantToRemove = Variants.FirstOrDefault(v => v.Size == chipText || v.Color == chipText);
            ComponentProductImages imageToRemove = Images.FirstOrDefault(i => i.Url == chipText);

            if (variantToRemove != null)
            {
                StaticListProductVariant.RemoveVariant(variantToRemove);
            }

            if(imageToRemove != null)
            {
                StaticListProductImage.RemoveImage(imageToRemove);
            }
        }

        public async Task OnInputImageChanged(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var images =  e.GetMultipleFiles(int.MaxValue);

            foreach (var image in images)
            {
                var resizedImage = await image.RequestImageFileAsync(format, 200, 200);
                var buffer = new byte[resizedImage.Size];
                await resizedImage.OpenReadStream().ReadAsync(buffer);
                var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}" ;
                productImage = new ComponentProductImages
                {
                    Url = image.Name,
                    Data = imageData
                };
                StaticListProductImage.AddImage(productImage);
            }
        }


        public async Task LoadsComponents()
        {
            Variants = StaticListProductVariant.GetVariants();
            Images = StaticListProductImage.GetImages();
        }

        public async Task AddingProductProcessing()
        {
            _processing = true;
            await Task.Delay(2000);


            var response = await ProductService.CreateProduct(new DTO_Product
            {
                Name = productDetail.Name,
                Description = productDetail.Description,
                BasePrice = productDetail.BasePrice,
                Variants = Variants,
                Images = Images
            });

            if (response.IsSuccess)
            {
                _processing = false;
                Snackbar.Clear();
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add(response.StatusMessage, Severity.Success);
            }
        }

    }
}

