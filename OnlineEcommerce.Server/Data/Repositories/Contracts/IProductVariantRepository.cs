using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductVariantRepository
    {
        Task<int> AddProductVariant(ProductVariant productVariant);
    }
}
