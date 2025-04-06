using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository = new UserRepository();

    public Task AddUserAsync(User user)
    {
        return _userRepository.AddUserAsync(user);
    }

    public Task<User?> GetUserByIdAsync(string id)
    {
        return _userRepository.GetUserByIdAsync(id);
    }

    public Task RemoveUserAsync(string id)
    {
        return _userRepository.DeleteUserAsync(id);
    }

    public Task UpdateUserAsync(User user)
    {
        return _userRepository.UpdateUserAsync(user);
    }

    public async Task<User?> UserAuthentication(string id, string password) 
    {
        var user = await GetUserByIdAsync(id);
        if(user is null || user.Password != password)
        {
            return null;
        }
        return user;
    }
}
