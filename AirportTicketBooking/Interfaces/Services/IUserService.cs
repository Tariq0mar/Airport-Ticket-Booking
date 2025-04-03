using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IUserService
{
    Task AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(string id);
    Task UpdateUserAsync(User user);
    Task RemoveUserAsync(string id);
}

