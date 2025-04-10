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


            // Seed Data for Products (10 Products)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Dell XPS 13", Price = 1200.00m, Quantity = 50, Category = "Electronics" },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 25.00m, Quantity = 200, Category = "Accessories" },
                new Product { Id = 3, Name = "Samsung Galaxy S23", Price = 900.00m, Quantity = 30, Category = "Electronics" },
                new Product { Id = 4, Name = "USB-C Cable", Price = 10.00m, Quantity = 500, Category = "Accessories" },
                new Product { Id = 5, Name = "Headphones Sony WH-1000XM5", Price = 350.00m, Quantity = 40, Category = "Electronics" },
                new Product { Id = 6, Name = "Keyboard Logitech K380", Price = 45.00m, Quantity = 150, Category = "Accessories" },
                new Product { Id = 7, Name = "Monitor LG 27-inch", Price = 300.00m, Quantity = 20, Category = "Electronics" },
                new Product { Id = 8, Name = "External Hard Drive 1TB", Price = 60.00m, Quantity = 100, Category = "Storage" },
                new Product { Id = 9, Name = "Smartwatch Fitbit Versa 4", Price = 200.00m, Quantity = 60, Category = "Wearables" },
                new Product { Id = 10, Name = "Power Bank 10000mAh", Price = 30.00m, Quantity = 300, Category = "Accessories" }
            );

            // Seed Data for Users (8 Users with Roles: Admin, User, Seller)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "ahmed_mohamed", Password = "Pass123!", Role = "Admin" },
                new User { Id = 2, UserName = "sara_ali", Password = "Sara2023", Role = "User" },
                new User { Id = 3, UserName = "mohamed_hassan", Password = "Mh12345", Role = "Seller" },
                new User { Id = 4, UserName = "fatima_khaled", Password = "Fatima99", Role = "Seller" },
                new User { Id = 5, UserName = "omar_youssef", Password = "Omar2023", Role = "Seller" },
                new User { Id = 6, UserName = "noura_ahmed", Password = "NouraPass", Role = "User" },
                new User { Id = 7, UserName = "khaled_mahmoud", Password = "Khaled123", Role = "Seller" },
                new User { Id = 8, UserName = "layan_said", Password = "Layan2023", Role = "Admin" }
            );

            // Seed Data for Sales (15 Sales, only by Sellers: UserId 3, 4, 5, 7)
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, ProductId = 1, UserId = 3, QuantitySold = 2, TotalPrice = 2400.00m, SaleDate = new DateTime(2025, 3, 1) },
                new Sale { Id = 2, ProductId = 2, UserId = 4, QuantitySold = 5, TotalPrice = 125.00m, SaleDate = new DateTime(2025, 3, 2) },
                new Sale { Id = 3, ProductId = 3, UserId = 5, QuantitySold = 1, TotalPrice = 900.00m, SaleDate = new DateTime(2025, 3, 3) },
                new Sale { Id = 4, ProductId = 4, UserId = 7, QuantitySold = 10, TotalPrice = 100.00m, SaleDate = new DateTime(2025, 3, 4) },
                new Sale { Id = 5, ProductId = 5, UserId = 3, QuantitySold = 1, TotalPrice = 350.00m, SaleDate = new DateTime(2025, 3, 5) },
                new Sale { Id = 6, ProductId = 6, UserId = 4, QuantitySold = 3, TotalPrice = 135.00m, SaleDate = new DateTime(2025, 3, 6) },
                new Sale { Id = 7, ProductId = 7, UserId = 5, QuantitySold = 2, TotalPrice = 600.00m, SaleDate = new DateTime(2025, 3, 7) },
                new Sale { Id = 8, ProductId = 8, UserId = 7, QuantitySold = 4, TotalPrice = 240.00m, SaleDate = new DateTime(2025, 3, 8) },
                new Sale { Id = 9, ProductId = 9, UserId = 3, QuantitySold = 1, TotalPrice = 200.00m, SaleDate = new DateTime(2025, 3, 9) },
                new Sale { Id = 10, ProductId = 10, UserId = 4, QuantitySold = 6, TotalPrice = 180.00m, SaleDate = new DateTime(2025, 3, 10) },
                new Sale { Id = 11, ProductId = 1, UserId = 5, QuantitySold = 1, TotalPrice = 1200.00m, SaleDate = new DateTime(2025, 3, 11) },
                new Sale { Id = 12, ProductId = 2, UserId = 7, QuantitySold = 8, TotalPrice = 200.00m, SaleDate = new DateTime(2025, 3, 12) },
                new Sale { Id = 13, ProductId = 3, UserId = 3, QuantitySold = 2, TotalPrice = 1800.00m, SaleDate = new DateTime(2025, 3, 13) },
                new Sale { Id = 14, ProductId = 4, UserId = 4, QuantitySold = 15, TotalPrice = 150.00m, SaleDate = new DateTime(2025, 3, 14) },
                new Sale { Id = 15, ProductId = 5, UserId = 5, QuantitySold = 1, TotalPrice = 350.00m, SaleDate = new DateTime(2025, 3, 15) }
            );
        }
    }
}