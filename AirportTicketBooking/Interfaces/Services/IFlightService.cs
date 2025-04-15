using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IFlightService
{
    Task AddAsync(Flight flight);
    Task<Flight?> GetByIdAsync(string id);
    Task<IEnumerable<Flight>> GetAllAsync();
    Task UpdateAsync(Flight flight);
    Task DeleteAsync(string id);
}
