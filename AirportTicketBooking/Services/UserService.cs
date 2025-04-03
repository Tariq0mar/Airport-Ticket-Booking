using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    public Task AddUserAsync(User user)
    {
        return _userRepository.AddUserAsync(user);
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public Task RemoveUserAsync(string id)
    {
        return _userRepository.DeleteUserAsync(id);
    }

    public Task UpdateUserAsync(User user)
    {
        return _userRepository.UpdateUserAsync(user);
    }
}
