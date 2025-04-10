using StockTrack.Services.DTOs;

namespace StockTrack.Services.services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByUserName(string name);
        Task<UserDto> Add(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task<List<UserDto>> GetSellersAsync();
    }
}
