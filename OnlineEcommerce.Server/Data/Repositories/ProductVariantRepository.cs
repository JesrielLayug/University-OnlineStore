using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductVariantRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<int> AddProductVariant(ProductVariant productVariant)
        {
            _db.ProductVariants.Add(productVariant);
            await _db.SaveChangesAsync();
            return productVariant.Id;
        }
    }
}
