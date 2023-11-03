using Microsoft.AspNetCore.Http.Metadata;
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

        public async Task<Response> Create(DTO_Product product)
        {
            try
            {
                DateTime dateTimeToInsert = DateTime.Now;
                string formattedDateTime = dateTimeToInsert.ToString("MM-dd-yyyy");

                var domainProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.BasePrice,
                    DateCreated = formattedDateTime,
                    OrganizationId = await _organization.GetById(product.OrganizationName)
                };

                var newProductId = await _product.Create(domainProduct);

                foreach(var image in product.Images)
                {
                    await _productImages.Create(new ProductImages
                    {
                        ProductId = newProductId,
                        Url = image.Url,
                        Data = image.Data
                    });
                }

                foreach(var variant in  product.Variants)
                {
                    await _productVariant.Create(new ProductVariant
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

        public async Task<Response> Delete(DTO_Product dtoproduct)
        {
            try
            {
                var product = await _product.GetById(dtoproduct.Id);
                await _product.Delete(product);
                await _productImages.DeleteByProductId(dtoproduct.Id);
                await _productVariant.Delete(dtoproduct.Id);

                return new Response
                {
                    IsSuccess = true,
                    StatusMessage = "Successfully deleted the product."
                };
            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusMessage = "Failed to delete the product."
                };
            }
        }

        public async Task<DTO_Product> GetById(int id)
        {
            var product = await _product.GetById(id);
            var images = await _productImages.GetByProductId(id);
            var variants = await _productVariant.GetByProductId(id);


            List<DTO_ProductImage> dtoImages = new List<DTO_ProductImage>();
            foreach(var image in images)
            {
                dtoImages.Add(new DTO_ProductImage
                {
                    Id = image.Id,
                    Url = image.Url,
                    Data = image.Data
                });
            }

            List<DTO_ProductVariant> dtoVariants = new List<DTO_ProductVariant>();
            foreach (var variant in variants)
            {
                dtoVariants.Add(new DTO_ProductVariant
                {
                    Id = variant.Id,
                    Stock = variant.Stock,
                    Size = variant.Size,
                    Color = variant.Color,
                    SKU = variant.SKU,
                    PriceModifier = variant.PriceModifier,
                });
            }

            var dtoProduct = new DTO_Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.Price,
                Images = dtoImages,
                Variants = dtoVariants
            };

            return dtoProduct;
        }

        public async Task<IEnumerable<DTO_Product>> GetProducts()
        {
            var domainProducts = await _product.GetAll();
            var domainImages = await _productImages.GetAll();
            var domainVariants = await _productVariant.GetAll();

            var dtoProducts = domainProducts.ConvertToDto(domainVariants, domainImages);

            return dtoProducts;
        }

        public async Task<Response> Update(DTO_Product product)
        {
            try
            {
                var existingProduct = await _product.GetById(product.Id);

                DateTime dateTimeToInsert = DateTime.Now;
                string formattedDateTime = dateTimeToInsert.ToString("MM-dd-yyyy");

                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.BasePrice;
                existingProduct.DateModified = formattedDateTime;

                var basicProductDetail = await _product.Update(existingProduct);


                // Updating the variant of the product
                var existingVariants = await _productVariant.GetByProductId(product.Id);
                string productSKU; 
                var updatedVariantIds = new List<int>();

                foreach (var variant in existingVariants)
                {
                    var newVariant = product.Variants.FirstOrDefault(v => v.Id == variant.Id);
                    if (newVariant != null)
                    {
                        // Update the existing variant
                        variant.Size = newVariant.Size;
                        variant.Color = newVariant.Color.Value;
                        variant.SKU = newVariant.SKU;
                        variant.PriceModifier = newVariant.PriceModifier;
                        variant.Stock = newVariant.Stock;

                        await _productVariant.Update(variant);
                        updatedVariantIds.Add(variant.Id);
                    }
                }

                foreach (var item in product.Variants)
                {
                    if (!updatedVariantIds.Contains(item.Id))
                    {
                        await _productVariant.Create(new ProductVariant
                        {
                            ProductId = product.Id,
                            Size = item.Size,
                            Color = item.Color.Value,
                            SKU = product.SKU,
                            PriceModifier = item.PriceModifier,
                            Stock = item.Stock
                        });
                    }
                }


                // Updating the images of the product
                var toBeDeletedImages = await _productImages.DeleteByProductId(product.Id);
                if (toBeDeletedImages)
                {
                    foreach (var image in product.Images)
                    {
                        await _productImages.Create(new ProductImages
                        {
                            ProductId = product.Id,
                            Url = image.Url,
                            Data = image.Data
                        });
                    }
                }

                return new Response
                {
                    IsSuccess = true,
                    StatusMessage = "The product is successfully updated.",
                };
            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusMessage = "Failed to update the product.",
                };
            }
        }
    }
}
