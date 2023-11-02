using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductImagesRepository
    {
        Task<IEnumerable<ProductImages>> GetAll();
        Task<int> Create(ProductImages images);
        Task<bool> Delete(int ProductId);
        Task<bool> Update(ProductImages images);
    }
}
