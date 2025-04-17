using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository = new FlightRepository();

    public async Task<string> AddAsync(Flight flight)
    {
        return await _flightRepository.AddAsync(flight);
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        return await _flightRepository.GetAllAsync();
    }

    public async Task<Flight?> GetByIdAsync(string id)
    {
        return await _flightRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(Flight flight)
    {
        return await _flightRepository.UpdateAsync(flight);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _flightRepository.DeleteAsync(id);
    }
}
