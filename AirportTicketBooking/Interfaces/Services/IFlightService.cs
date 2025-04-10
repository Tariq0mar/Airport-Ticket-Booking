using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IFlightService
{
    Task AddAsync(Flight flight);
    Task<Flight?> GetByIdAsync(string id);
    Task<IEnumerable<Flight>> GetAllAsync();
    Task<bool> UpdateAsync(Flight flight);
    Task<bool> DeleteAsync(string id);
}
