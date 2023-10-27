using OnlineEcommerce.Server.Data.Repositories;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Extensions;
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
        private readonly IProductImagesRepository _productImages;

        public ProductService(IProductRepository product, IOrganizationRepository organization, 
                              IProductVariantRepository productVariant, IProductImagesRepository productImages)
        {
            this._product = product;
            this._organization = organization;
            this._productVariant = productVariant;
            this._productImages = productImages;
        }

        public async Task<Response> CreateProduct(DTO_Product product)
        {
            try
            {

                var domainProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.BasePrice,
                    OrganizationId = await _organization.GetById(product.OrganizationName)
                };

                var newProductId = await _product.CreateProduct(domainProduct);

                foreach(var image in product.Images)
                {
                    await _productImages.CreateProductImages(new ProductImages
                    {
                        ProductId = newProductId,
                        Url = image.Url,
                        Data = image.Data
                    });
                }

                foreach(var variant in  product.Variants)
                {
                    await _productVariant.AddProductVariant(new ProductVariant
                    {
                        ProductId = newProductId,
                        Size = variant.Size,
                        Color = variant.Color.ToString(),
                        Stock = variant.Stock,
                        PriceModifier = variant.PriceModifier,
                        SKU = SKUGenerator.GenerateSKU(product.Name, product.OrganizationName, newProductId)
                    });
                }

                return new Response
                {
                    IsSuccess = true,
                    StatusMessage = "The product is successfully created.",
                };
            }
            catch (Exception)
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusMessage = "There is something wrong with the server.",
                };
            }
        }

        public async Task<IEnumerable<DTO_Product>> GetProducts()
        {
            var domainProducts = await _product.GetAll();
            var domainImages = await _productImages.GetAll();
            var domainVariants = await _productVariant.GetAll();

            var dtoProducts = domainProducts.ConvertToDto(domainVariants, domainImages);

            return dtoProducts;
        }
    }
}
