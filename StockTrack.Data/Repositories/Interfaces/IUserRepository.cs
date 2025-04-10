using StockTrack.Data.Entities;

namespace StockTrack.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> GetByUserName(string username);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<List<User>> GetSellersAsync();
    }
}
