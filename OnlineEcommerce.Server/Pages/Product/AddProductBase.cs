
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Utilities;
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


        public List<DTO_ProductImage> Images = new List<DTO_ProductImage>();
        public List<DTO_ProductVariant> Variants = new List<DTO_ProductVariant>();

        public DTO_ProductDetail product = new DTO_ProductDetail();
        public DTO_ProductVariant variant = new DTO_ProductVariant();
        public DTO_ProductImage productImage;


        public bool _processing = false;

        public AddProductBase()
        {
            LoadsComponents().Wait();
        }

        public void AddVariant()
        {
            if(!string.IsNullOrWhiteSpace(variant.Size) || !string.IsNullOrWhiteSpace(variant.Color.ToString()))
            {
                StaticListProductVariant.AddVariant(new DTO_ProductVariant
                {
                    Color = variant.Color,
                    Size = variant.Size,
                    PriceModifier = variant.PriceModifier,
                    Stock = variant.Stock,
                });
            }
        }

        public void RemoveChip(MudChip chip)
        {
            string chipText = chip.Text;
            DTO_ProductVariant variantToRemove = Variants.FirstOrDefault(v => v.Size == chipText || v.Color == chipText);
            DTO_ProductImage imageToRemove = Images.FirstOrDefault(i => i.Url == chipText);

            if (variantToRemove != null)
            {
                StaticListProductVariant.RemoveVariant(variantToRemove);
            }

            if (imageToRemove != null)
            {
                StaticListProductImage.RemoveImage(imageToRemove);
            }
        }

        public async Task OnInputImageChanged(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var images = e.GetMultipleFiles(int.MaxValue);

            foreach (var image in images)
            {
                var resizedImage = await image.RequestImageFileAsync(format, 200, 200);
                var buffer = new byte[resizedImage.Size];
                await resizedImage.OpenReadStream().ReadAsync(buffer);
                var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                productImage = new DTO_ProductImage
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

        public void ResetPage()
        {
            product = new DTO_ProductDetail();
            StaticListProductImage.RemoveAll(Images);
            StaticListProductVariant.RemoveAll(Variants);
        }

        public async Task AddingProductProcessing()
        {
            _processing = true;
            await Task.Delay(2000);
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

            if (Variants.Count == 0 || Images.Count == 0)
            {
                _processing = false;
                Snackbar.Add("Please complete each field.", Severity.Error);
            }
            else 
            {
                var response = await ProductService.CreateProduct(new DTO_Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    BasePrice = product.BasePrice,
                    Variants = Variants,
                    Images = Images
                });

                if (response.IsSuccess)
                {
                    _processing = false;
                    ResetPage();
                    Snackbar.Add(response.StatusMessage, Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    _processing = false;
                    Snackbar.Add(response.StatusMessage, Severity.Error);
                }
            } 
        }

    }
}

