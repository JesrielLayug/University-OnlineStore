
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

        [Inject]
        NavigationManager NavigationManager { get; set; }


        // Adding Products Properties
        public List<DTO_ProductImage> Images = new List<DTO_ProductImage>();
        public List<DTO_ProductVariant> Variants = new List<DTO_ProductVariant>();

        public DTO_ProductDetail productDetail = new DTO_ProductDetail();
        public DTO_ProductVariant variant = new DTO_ProductVariant();
        public DTO_ProductImage productImage;

        public bool _processing = false;


        // Edit Products Property
        public DTO_Product Product;

        public AddProductBase()
        {
            LoadsComponents().Wait();
        }

        protected override async Task OnInitializedAsync()
        {
            Product = StaticProduct.GetProduct();

            if (Product.Id != 0)
            {
                productDetail.Name = Product.Name;
                productDetail.Description = Product.Description;
                productDetail.BasePrice = Product.BasePrice;
                Images = Product.Images;
                Variants = Product.Variants;
            }
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
            productDetail = new DTO_ProductDetail();
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
                    Name = productDetail.Name,
                    Description = productDetail.Description,
                    BasePrice = productDetail.BasePrice,
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

        public async Task ClearForm(DTO_Product product)
        {
            await StaticProduct.RemoveProductToEdit(product);
            ResetPage();
            StateHasChanged();
        }

    }
}

