using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Pages.Product.Components;
using OnlineEcommerce.Server.Services.Contracts;
using OnlineEcommerce.Server.Utilities;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class ManageProductBase : ComponentBase
    {
        [Inject]
        IProductService ProductService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        public bool isLoading = true;

        // For limiting the description and title text of a product
        public StringFunction Text = new StringFunction();

        // For table of Products
        public string searchString1 = "";
        public HashSet<DTO_Product> selectedProducts = new HashSet<DTO_Product>();
        public IEnumerable<DTO_Product> Products;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                Products = await ProductService.GetProducts();
                isLoading = false;
                StateHasChanged();
            }
        }

        public void NavigateToAddProductPage() => NavigationManager.NavigateTo("/create-product");

        public bool FilterProduct1(DTO_Product product) => FilterProduct(product, searchString1);

        public bool FilterProduct(DTO_Product product, string searchString)
        {
            var id = product.Variants.FirstOrDefault(s => s.Id.ToString() == searchString);
            var sku = product.Variants.FirstOrDefault(s => s.SKU.ToString() == searchString);
            var size = product.Variants.FirstOrDefault(s => s.Size.ToString() == searchString);
            var color = product.Variants.FirstOrDefault(s => s.Color.ToString() == searchString);

            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{id} {sku} {size} {color}".Contains(searchString))
                return true;

            return false;
        }

        public async Task ShowDeleteDialog(DTO_Product product)
        {
            var parameter = new DialogParameters<DeleteProductDialog>();
            parameter.Add(x => x.product, product);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = await DialogService.ShowAsync<DeleteProductDialog>("Delete", parameter, options);

            var result = dialog.Result;

            if(result.IsCompleted)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
        
        }

        public async Task EditProduct(int productId)
        {
            StaticProductId.InsertProductToEdit(productId);
            NavigationManager.NavigateTo("/edit-product", forceLoad: true);
        }
    }
}
