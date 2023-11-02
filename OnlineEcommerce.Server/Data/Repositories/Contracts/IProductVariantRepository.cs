using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductVariantRepository
    {
        Task<IEnumerable<ProductVariant>> GetAll();
        Task<int> Create(ProductVariant productVariant);
        Task<int?> GetBySKU(string SKU);
        Task<bool> Delete(int ProductId);
        Task<bool> Update(ProductVariant productVariant);
    }
}
