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

        public async Task<int> Create(ProductVariant productVariant)
        {
            _db.ProductVariants.Add(productVariant);
            await _db.SaveChangesAsync();
            return productVariant.Id;
        }

        public async Task<bool> Delete(int ProductId)
        {
            var variant = await _db.ProductVariants.Where(x => x.ProductId == ProductId).ToListAsync();
            _db.ProductVariants.RemoveRange(variant);
            var change = await _db.SaveChangesAsync();
            return change > 0;
        }

        public async Task<IEnumerable<ProductVariant>> GetAll()
        {
            var variants = await _db.ProductVariants.ToListAsync();
            return variants;
        }

        public async Task<int?> GetBySKU(string SKU)
        {
            var product = await _db.ProductVariants.FirstOrDefaultAsync(p => p.SKU == SKU);
            return product.ProductId;
        }

        public async Task<bool> Update(ProductVariant productVariant)
        {
            _db.ProductVariants.Update(productVariant);
            var change = await _db.SaveChangesAsync();
            return change > 0;
        }
    }
}
