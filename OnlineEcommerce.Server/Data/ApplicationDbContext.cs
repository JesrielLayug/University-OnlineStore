using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Organization>().HasData(new Organization
            {
                Id = 1,
                Name = "COOP"
            });
            modelBuilder.Entity<Organization>().HasData(new Organization
            {
                Id = 2,
                Name = "Computing Studies"
            });
            modelBuilder.Entity<Organization>().HasData(new Organization
            {
                Id = 3,
                Name = "Bussineess Studies"
            });
            modelBuilder.Entity<Organization>().HasData(new Organization
            {
                Id = 4,
                Name = "Engineering Studies"
            });

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

    }
}
