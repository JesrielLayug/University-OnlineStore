using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductImagesRepository
    {
        Task<IEnumerable<ProductImages>> GetAll();
        Task<List<ProductImages>> GetByProductId(int productId);
        Task<bool> DeleteByProductId(int ProductId);
        Task<int> Create(ProductImages images);
        Task<bool> Update(ProductImages images);
        Task<bool> Delete(ProductImages images);
    }
}
