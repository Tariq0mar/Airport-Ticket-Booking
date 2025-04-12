using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository = new UserRepository();

    public async Task AddAsync(User user)
    {
        await _userRepository.AddAsync(user);
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string id)
    {
        return await _userRepository.GetByEmailAsync(id);
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task RemoveAsync(string id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task<User?> UserAuthentication(string id, string password)
    {
        var user = await GetByIdAsync(id);
        if (user is null || user.Password != password)
        {
            return null;
        }
        return user;
    }
}
