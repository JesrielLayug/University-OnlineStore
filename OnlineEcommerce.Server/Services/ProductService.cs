using OnlineEcommerce.Server.Data.Repositories;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        private readonly IOrganizationRepository _organization;

        public ProductService(IProductRepository product, IOrganizationRepository organization)
        {
            this._product = product;
            this._organization = organization;
        }

        public async Task<Response<int?>> CreateProduct(DTO_Product product)
        {
            try
            {
                var productExist = await _product.GetByName(product.Name);
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
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.BasePrice,
                    OrganizationId = organizationId,
                };

                var newProduct = await _product.CreateProduct(domainProduct);

                return new Response<int?>
                {
                    IsSuccess = true,
                    StatusMessage = "The product is successfully created.",
                    Data = newProduct
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
