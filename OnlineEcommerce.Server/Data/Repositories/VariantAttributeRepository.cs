using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class VariantAttributeRepository : IVariantAttributeRepository
    {
        private readonly ApplicationDbContext _db;

        public VariantAttributeRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAttribute(VariantAttribute variantAttribute)
        {
            _db.Attributes.Add(variantAttribute);
            await _db.SaveChangesAsync();
            return variantAttribute.Id;
        }

        public async Task<IEnumerable<VariantAttribute>> GetAttributes()
        {
            var attributes = await _db.Attributes.ToListAsync();
            return attributes;
        }

        public async Task<VariantAttribute> GetByName(string name)
        {
            var attribute = await _db.Attributes.FirstOrDefaultAsync(x => x.Name == name);
            return attribute;
        }
    }
}
