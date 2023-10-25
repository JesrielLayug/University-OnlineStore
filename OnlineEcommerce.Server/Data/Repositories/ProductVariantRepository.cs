using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ProductVariant>> GetAll()
        {
            var variants = await _db.ProductVariants.ToListAsync();
            return variants;
        }

        public async Task<int?> GetProductVariantBySKU(string SKU)
        {
            var product = await _db.ProductVariants.FirstOrDefaultAsync(p => p.SKU == SKU);
            return product.ProductId;
        }
    }
}
