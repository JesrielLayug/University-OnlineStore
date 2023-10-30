using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductImagesRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<int> CreateProductImages(ProductImages images)
        {
            _db.ProductImages.Add(images);
            await _db.SaveChangesAsync();
            return images.Id;
        }

        public async Task<bool> DeleteImagesByProductId(int ProductId)
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
    }
}
