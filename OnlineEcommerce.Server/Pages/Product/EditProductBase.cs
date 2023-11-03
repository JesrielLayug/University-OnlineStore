
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
    public class EditProductBase : ComponentBase
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
        public DTO_ProductVariant selectedVariant = null;


        // Edit Products Property
        public int ProductId;
        public DTO_Product ProductToBeEdit;

        public int productStock;

        public EditProductBase()
        {
            LoadsComponents();
        }

        protected override async Task OnInitializedAsync()
        {
            ResetPage();
            ProductId = StaticProductId.GetProduct();

            if(ProductId != 0)
            {
                ProductToBeEdit = await ProductService.GetById(ProductId);

                productDetail.Name = ProductToBeEdit.Name;
                productDetail.BasePrice = ProductToBeEdit.BasePrice;
                productDetail.Description = ProductToBeEdit.Description;
                foreach (var image in ProductToBeEdit.Images)
                {
                    StaticListProductImage.AddImage(image);
                }
                foreach (var item in ProductToBeEdit.Variants)
                {
                    StaticListProductVariant.AddVariant(item);
                }
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
            else
            {
                Snackbar.Clear();
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Please add stock to the variant.", Severity.Error);
            }
        }

        public async Task RemoveVariantChip(MudChip chip)
        {
            string chipText = chip.Text;
            DTO_ProductVariant variantToRemove = Variants.FirstOrDefault(v => v.Size == chipText || v.Color == chipText);
            
            if (variantToRemove != null)
            {
                StaticListProductVariant.RemoveVariant(variantToRemove);
            }
        }

        public async Task RemoveImageChip(MudChip chip)
        {
            string chipText = chip.Text;
            DTO_ProductImage imageToRemove = Images.FirstOrDefault(i => i.Url == chipText);

            if (imageToRemove != null)
            {
                StaticListProductImage.RemoveImage(imageToRemove);
                StateHasChanged();
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
                StateHasChanged();
            }
        }


        public void LoadsComponents()
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

                var response = await ProductService.Create(new DTO_Product
                {
                    Id = ProductId,
                    Name = productDetail.Name,
                    Description = productDetail.Description,
                    BasePrice = productDetail.BasePrice,
                    SKU = Variants[0].SKU,
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

        public async Task UpdateProduct()
        {
            _processing = true;
            await Task.Delay(2000);
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

            if(Variants.Count == 0 || Images.Count == 0)
            {
                _processing = false;
                Snackbar.Add("Please complete each field.", Severity.Error);
            }
            else
            {
                var response = await ProductService.Update(new DTO_Product
                {
                    Id = ProductToBeEdit.Id,
                    Name = productDetail.Name,
                    Description = productDetail.Description,
                    BasePrice = productDetail.BasePrice,
                    SKU = ProductToBeEdit.Variants[0].SKU,
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

        public async Task ClearForm()
        {
            await StaticProductId.RemoveProductToEdit(ProductId);
            ResetPage();
            StateHasChanged();
        }

    }
}

