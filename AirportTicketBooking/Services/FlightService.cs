using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository = new FlightRepository();

    public async Task AddAsync(Flight flight)
    {
        await _flightRepository.AddAsync(flight);
    }

    public async Task DeleteAsync(string id)
    {
        await _flightRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        return await _flightRepository.GetAllAsync();
    }

    public async Task<Flight?> GetByIdAsync(string id)
    {
        return await _flightRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Flight flight)
    {
        await _flightRepository.UpdateAsync(flight);
    }
}
