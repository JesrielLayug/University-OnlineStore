using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductImagesRepository
    {
        Task<IEnumerable<ProductImages>> GetAll();
        Task<int> CreateProductImages(ProductImages images);
    }
}
