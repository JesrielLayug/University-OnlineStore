using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductImagesRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<int> Create(ProductImages images)
        {
            _db.ProductImages.Add(images);
            await _db.SaveChangesAsync();
            return images.Id;
        }


        public async Task<bool> DeleteByProductId(int ProductId)
        {
            var image = await _db.ProductImages.Where(x => x.ProductId == ProductId).ToListAsync();
            _db.ProductImages.RemoveRange(image);
            var change = await _db.SaveChangesAsync();
            return change > 0;
        }

        public async Task<IEnumerable<ProductImages>> GetAll()
        {
            var images = await _db.ProductImages.ToListAsync();
            return images;
        }

        public async Task<List<ProductImages>> GetByProductId(int productId)
        {
            var images =  await _db.ProductImages.Where(i => i.ProductId == productId).ToListAsync();
            return images;
        }

        public async Task<bool> Update(ProductImages images)
        {
            _db.ProductImages.Update(images);
            var change = await _db.SaveChangesAsync();
            return change > 0;
        }

        public async Task<bool> Delete(ProductImages images)
        {
            _db.ProductImages.Remove(images);
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
    }
}
