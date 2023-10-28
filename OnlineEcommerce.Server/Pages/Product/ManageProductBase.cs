﻿using Microsoft.AspNetCore.Components;
using OnlineEcommerce.Server.Models.DTOs;
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

        public string searchString1 = "";

        public HashSet<DTO_Product> selectedProducts = new HashSet<DTO_Product>();
        public IEnumerable<DTO_Product> Products;

        public DTO_Product product = new DTO_Product();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                Products = await ProductService.GetProducts();
                StateHasChanged();
            }
        }

        public void NavigateToAddProductPage() => NavigationManager.NavigateTo("/create-product");

        public bool FilterProduct1(DTO_Product product) => FilterProduct(product, searchString1);

        public bool FilterProduct(DTO_Product product, string searchString)
        {
            var stock = product.Variants.FirstOrDefault(s => s.Stock.ToString() == searchString);
            var sku = product.Variants.FirstOrDefault(s => s.SKU.ToString() == searchString);
            var size = product.Variants.FirstOrDefault(s => s.Size.ToString() == searchString);
            var color = product.Variants.FirstOrDefault(s => s.Color.ToString() == searchString);

            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{stock} {sku} {size} {color}".Contains(searchString))
                return true;

            return false;
        }
    }
}
