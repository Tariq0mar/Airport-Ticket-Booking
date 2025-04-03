using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Repositories;

public interface IFlightRepository
{
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetFlightByIdAsync(string id);
    Task UpdateFlightAsync(Flight flight);
    Task DeleteFlightAsync(string id);
}

