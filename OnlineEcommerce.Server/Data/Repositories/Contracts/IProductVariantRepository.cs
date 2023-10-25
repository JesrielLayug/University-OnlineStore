using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductVariantRepository
    {
        Task<IEnumerable<ProductVariant>> GetAll();
        Task<int> AddProductVariant(ProductVariant productVariant);
        Task<int?> GetProductVariantBySKU(string SKU);
    }
}
