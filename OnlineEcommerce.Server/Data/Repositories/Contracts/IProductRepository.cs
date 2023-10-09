using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
