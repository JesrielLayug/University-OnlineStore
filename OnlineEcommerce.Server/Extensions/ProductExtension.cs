
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Extensions
{
    public static class ProductExtension
    {
        public static IEnumerable<DTO_Product> ConvertToDto(this 
                                                            IEnumerable<Product> products,
                                                            IEnumerable<ProductVariant> productVariants,
                                                            IEnumerable<ProductImages> images)
        {
            return products.Select(product => new DTO_Product
            {
                Id = product.Id,
                Name = product.Name,
                BasePrice = product.Price,
                Description = product.Description,
                Images = images
                    .Where(image => image.ProductId == product.Id)
                    .Select(image => new DTO_ProductImage
                    {
                        Id = image.Id,
                        Url = image.Url,
                        Data = image.Data
                    }).ToList(),
                Variants = productVariants
                    .Where(variant => variant.ProductId == product.Id)
                    .Select(variant => new DTO_ProductVariant
                    {
                        Id = variant.Id,
                        Color = variant.Color,
                        Size = variant.Size,
                        PriceModifier = variant.PriceModifier,
                        Stock = variant.Stock,
                        SKU = variant.SKU
                    }).ToList()
            });
        }
    }
}
