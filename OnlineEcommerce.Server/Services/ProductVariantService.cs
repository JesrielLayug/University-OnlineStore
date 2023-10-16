using OnlineEcommerce.Server.Data;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Services
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly IProductVariantRepository _productVariantRepository;

        public ProductVariantService(IProductVariantRepository productVariantRepository)
        {
            this._productVariantRepository = productVariantRepository;
        }

        public async Task<bool> AddProductVariant(DTO_ProductVariant productVariant)
        {
            var domain = new ProductVariant
            {
                ProductId = productVariant.ProductId,
                VariantId = productVariant.VariantId,
                Stock = productVariant.Stock,
                PriceModifier = productVariant.PriceModifier,
            };

            return await _productVariantRepository.AddProductVariant(domain) > 0;
        }
    }
}
