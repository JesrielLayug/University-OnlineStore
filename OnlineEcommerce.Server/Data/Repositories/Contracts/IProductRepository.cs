using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> GetByName(string name);
        Task<int> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);
    }
}
