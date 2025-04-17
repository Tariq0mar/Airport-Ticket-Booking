using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IUserService
{
    Task<string> AddAsync(User user);
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(string id);
}

