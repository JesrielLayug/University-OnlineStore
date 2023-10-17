using OnlineEcommerce.Server.Data.Repositories;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;
using OnlineEcommerce.Server.Utilities;

namespace OnlineEcommerce.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        private readonly IOrganizationRepository _organization;
        private readonly IProductVariantRepository _productVariant;

        public ProductService(IProductRepository product, IOrganizationRepository organization, IProductVariantRepository productVariant)
        {
            this._product = product;
            this._organization = organization;
            this._productVariant = productVariant;
        }

        public async Task<Response<int?>> CreateProduct(DTO_Product product)
        {
            try
            {
                var productExist = await _productVariant.GetProductVariantBySKU(product.SKU);
                if (productExist != null)
                {
                    return new Response<int?>
                    {
                        IsSuccess = false,
                        StatusMessage = "The product is already used. Please try another one.",
                        Data = null
                    };
                }

                var organizationId = await _organization.GetById(product.OrganizationName);
                
                var domainProduct = new Product
                {
                    Name = product.ProductName,
                    Description = product.Description,
                    Price = product.BasePrice,
                    OrganizationId = organizationId,
                };

                var newProduct = await _product.CreateProduct(domainProduct); // returns the new productId
                var productSku = SKUGenerator.GenerateSKU(product.ProductName, product.OrganizationName, newProduct);

                var domainProductVariant = new ProductVariant
                {
                    ProductId = newProduct,
                    Size = product.Size,
                    Color = product.Color,
                    Stock = product.Stock,
                    PriceModifier = product.PriceModifier,
                    SKU = productSku,
                };

                return new Response<int?>
                {
                    IsSuccess = true,
                    StatusMessage = "The product is successfully created.",
                    Data = await _productVariant.AddProductVariant(domainProductVariant)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
