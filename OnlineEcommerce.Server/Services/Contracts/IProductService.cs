using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<DTO_Product>> GetProducts();
        Task<Response> CreateProduct(DTO_Product product);
        Task<Response> DeleteProduct(DTO_Product product);
    }
}
