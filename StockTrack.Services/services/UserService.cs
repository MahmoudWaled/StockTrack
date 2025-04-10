using AutoMapper;
using StockTrack.Data.Entities;
using StockTrack.Data.Repositories.Interfaces;
using StockTrack.Services.DTOs;
using StockTrack.Services.services.Interfaces;

namespace StockTrack.Services.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }

        // Retrieve all users
        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();
            return mapper.Map<List<UserDto>>(users);
        }

        // Add a new user
        public async Task<UserDto> Add(UserDto userDto)
        {
            var entityUser = mapper.Map<User>(userDto);
            await userRepository.Add(entityUser);
            return userDto;
        }

        // Retrieve a user by their ID
        public async Task<UserDto> GetById(int id)
        {
            var entityUser = await userRepository.GetById(id);
            return mapper.Map<UserDto>(entityUser);
        }

        // Retrieve a user by their username
        public async Task<UserDto> GetByUserName(string name)
        {
            var entityUser = await userRepository.GetByUserName(name);
            return mapper.Map<UserDto>(entityUser);
        }

        // Retrieve all sellers
        public async Task<List<UserDto>> GetSellersAsync()
        {
            var sellers = await userRepository.GetSellersAsync();
            return mapper.Map<List<UserDto>>(sellers);
        }

        // Update an existing user
        public async Task<UserDto> Update(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "User data cannot be null.");
            }

            var user = mapper.Map<User>(userDto);
            await userRepository.Update(user);
            return userDto;
        }
    }
}