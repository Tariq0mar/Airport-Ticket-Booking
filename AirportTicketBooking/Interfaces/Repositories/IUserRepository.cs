using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Repositories;

public interface IUserRepository
{
    Task<string> AddAsync(User user);
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(string id);
}
