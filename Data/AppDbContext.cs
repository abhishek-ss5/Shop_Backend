using Microsoft.EntityFrameworkCore;
using ShopManagement.Entities;

namespace ShopManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: configure cascade delete
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product!)
                .HasForeignKey(s => s.Product_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}













//using Microsoft.EntityFrameworkCore;
//using ShopManagement.Entities;

//namespace ShopManagement.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions options) : base(options) { }

//        public DbSet<Product> Products { get; set; }
//        public DbSet<Sale> Sales { get; set; }
//    }
//}

