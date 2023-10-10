using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class VariantRepository : IVariantRepository
    {
        private readonly ApplicationDbContext _db;

        public VariantRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Variant>> GetAllVariants()
        {
            var variants = await _db.Variants.ToListAsync();
            return variants;
        }

        public async Task<int> AddVariant(Variant variant)
        {
            _db.Variants.Add(variant);
            await _db.SaveChangesAsync();
            return variant.Id;
        }
    }
}
