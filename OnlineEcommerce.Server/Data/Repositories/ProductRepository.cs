using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product> GetByName(string name)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Name == name);
            return product;
        }

        public async Task<int> CreateProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            var change = await _db.SaveChangesAsync();
            return change > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            var change = await _db.SaveChangesAsync();
            return change > 0;
        }
    }
}
