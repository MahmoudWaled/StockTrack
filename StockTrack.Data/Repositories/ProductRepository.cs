using Microsoft.EntityFrameworkCore;
using StockTrack.Data.Data;
using StockTrack.Data.Entities;
using StockTrack.Data.Repositories.Interfaces;

namespace StockTrack.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        // Retrieve all products from the database
        public async Task<List<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        // Add a new product to the database
        public async Task<Product> Add(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        // Delete a product by its ID, with validation for related sales
        public async Task Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            var hasSales = await context.Sales.AnyAsync(s => s.ProductId == id);
            if (hasSales)
            {
                throw new InvalidOperationException($"Cannot delete Product with ID {id} because it has related Sales. Please delete the related Sales first.");
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        // Retrieve a product by its ID
        public async Task<Product> GetById(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            return product;
        }

        // Update an existing product
        public async Task<Product> Update(Product product)
        {
            var oldProduct = await context.Products.FindAsync(product.Id);
            if (oldProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
            }

            context.Entry(oldProduct).CurrentValues.SetValues(product);
            await context.SaveChangesAsync();
            return product;
        }

        // Search for products by name (case-insensitive)
        public async Task<List<Product>> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Search name cannot be null or empty.", nameof(name));
            }

            return await context.Products
                .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        // Update the quantity of a product after a sale
        public async Task UpdateProductQuantityAsync(int productId, int quantitySold)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            if (quantitySold > product.Quantity)
            {
                throw new InvalidOperationException($"Only {product.Quantity} items are available in stock.");
            }

            product.Quantity -= quantitySold;
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}