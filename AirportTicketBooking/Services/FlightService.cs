using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository = new FlightRepository();

    public async Task AddFlightAsync(Flight flight)
    {
        await _flightRepository.AddFlightAsync(flight);
    }

    public async Task DeleteFlightAsync(string id)
    {
        await _flightRepository.DeleteFlightAsync(id);
    }

    public async Task<Flight?> GetFlightByIdAsync(string id)
    {
        return await _flightRepository.GetFlightByIdAsync(id);
    }

    public async Task UpdateFlightAsync(Flight flight)
    {
        await _flightRepository.UpdateFlightAsync(flight);
    }
}
