using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<DTO_Product>> GetProducts();
        Task<Response> Create(DTO_Product product);
        Task<Response> Update(DTO_Product product);
        Task<Response> Delete(DTO_Product product);
    }
}
