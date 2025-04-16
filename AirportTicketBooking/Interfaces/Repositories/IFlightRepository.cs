using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Repositories;

public interface IFlightRepository
{
    Task<string> AddAsync(Flight flight);
    Task<Flight?> GetByIdAsync(string id);
    Task<IEnumerable<Flight>> GetAllAsync();
    Task<bool> UpdateAsync(Flight flight);
    Task<bool> DeleteAsync(string id);
}

