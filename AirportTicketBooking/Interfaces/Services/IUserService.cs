using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IUserService
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task UpdateAsync(User user);
    Task RemoveAsync(string id);
}

