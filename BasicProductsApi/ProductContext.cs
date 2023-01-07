global using Microsoft.EntityFrameworkCore;

namespace BasicProductsApi
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
    }
    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.Entity<Product>().HasData(
    //        new Product { ProductId = 1, Name = "Example Product 1", Description = "Example ", Price = 1, InStock = true },
    //        new Product { ProductId = 2, Name = "Example Product 2", Description = "Example ", Price = 2, InStock = true },
    //        new Product { ProductId = 3, Name = "Example Product 3", Description = "Example ", Price = 3, InStock = true },
    //        new Product { ProductId = 4, Name = "Example Product 4", Description = "Example ", Price = 4, InStock = true },
    //        new Product { ProductId = 5, Name = "Example Product 5", Description = "Example ", Price = 5, InStock = true },
    //        new Product { ProductId = 6, Name = "Example Product 6", Description = "Example ", Price = 6, InStock = true }
    //        );
    //} 
}
