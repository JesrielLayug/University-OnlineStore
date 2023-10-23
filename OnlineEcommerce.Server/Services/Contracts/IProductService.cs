using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IProductService
    {
        Task<Response> CreateProduct(DTO_Product product);
    }
}
