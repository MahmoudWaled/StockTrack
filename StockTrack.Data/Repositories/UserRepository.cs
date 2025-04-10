using Microsoft.EntityFrameworkCore;
using StockTrack.Data.Data;
using StockTrack.Data.Entities;
using StockTrack.Data.Repositories.Interfaces;

namespace StockTrack.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        // Retrieve all users from the database
        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }

        // Add a new user to the database
        public async Task<User> Add(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        // Retrieve a user by their ID
        public async Task<User> GetById(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }

        // Retrieve a user by their username
        public async Task<User> GetByUserName(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with username '{username}' not found.");
            }
            return user;
        }

        // Retrieve all users with the "Seller" role
        public async Task<List<User>> GetSellersAsync()
        {
            return await context.Users
                .Where(u => u.Role == "Seller" && !string.IsNullOrEmpty(u.UserName))
                .ToListAsync();
        }

        // Update an existing user
        public async Task<User> Update(User user)
        {
            var oldUser = await context.Users.FindAsync(user.Id);
            if (oldUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }

            context.Entry(oldUser).CurrentValues.SetValues(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}