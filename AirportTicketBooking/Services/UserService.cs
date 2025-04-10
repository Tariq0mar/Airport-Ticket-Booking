using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository = new UserRepository();

    public Task AddAsync(UserRole user)
    {
        return _userRepository.AddAsync(user);
    }

    public Task<UserRole?> GetByIdAsync(string id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public Task<UserRole?> GetByEmailAsync(string id)
    {
        return _userRepository.GetByEmailAsync(id);
    }

    public Task RemoveAsync(string id)
    {
        return _userRepository.DeleteAsync(id);
    }

    public Task UpdateAsync(UserRole user)
    {
        return _userRepository.UpdateAsync(user);
    }

    public async Task<UserRole?> UserAuthentication(string id, string password) 
    {
        var user = await GetByIdAsync(id);
        if(user is null || user.Password != password)
        {
            return null;
        }
        return user;
    }
}
