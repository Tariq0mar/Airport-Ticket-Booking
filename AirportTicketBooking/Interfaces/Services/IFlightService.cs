using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IFlightService
{
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetFlightByIdAsync(string id);
    Task UpdateFlightAsync(Flight flight);
    Task DeleteFlightAsync(string id);
}
