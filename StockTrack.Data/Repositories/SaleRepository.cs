using Microsoft.EntityFrameworkCore;
using StockTrack.Data.Data;
using StockTrack.Data.Entities;
using StockTrack.Data.Repositories.Interfaces;

namespace StockTrack.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext context;

        public SaleRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        // Add a new sale to the database
        public async Task<Sale> Add(Sale sale)
        {
            await context.Sales.AddAsync(sale);
            await context.SaveChangesAsync();
            return sale;
        }

        // Retrieve all sales with related Product and User data
        public async Task<List<Sale>> GetAll()
        {
            return await context.Sales
                .Include(s => s.Product)
                .Include(s => s.User)
                .ToListAsync();
        }

        // Retrieve a sale by its ID with related Product and User data
        public async Task<Sale> GetById(int id)
        {
            var sale = await context.Sales
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {id} not found.");
            }
            return sale;
        }

        // Update an existing sale
        public async Task<Sale> Update(Sale sale)
        {
            var oldSale = await context.Sales.FindAsync(sale.Id);
            if (oldSale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {sale.Id} not found.");
            }

            context.Entry(oldSale).CurrentValues.SetValues(sale);
            await context.SaveChangesAsync();
            return sale;
        }

        // Delete a sale by its ID
        public async Task Delete(int id)
        {
            var sale = await context.Sales.FindAsync(id);
            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {id} not found.");
            }

            context.Sales.Remove(sale);
            await context.SaveChangesAsync();
        }
    }
}