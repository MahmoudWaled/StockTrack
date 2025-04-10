using Microsoft.EntityFrameworkCore;
using StockTrack.Data.Entities;

namespace StockTrack.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }

        // Configure entity relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many: Product -> Sale
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many: User -> Sale
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sales)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}