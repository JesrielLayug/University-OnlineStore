using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IProductImagesRepository
    {
        Task<int> CreateProductImages(ProductImages images);
    }
}
