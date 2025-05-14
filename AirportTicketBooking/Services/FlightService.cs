using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _repository;

    public FlightService(IFlightRepository repository)
    {
        _repository = repository;
    }
    public async Task<string> AddAsync(Flight flight)
    {
        return await _repository.AddAsync(flight);
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Flight?> GetByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(Flight flight)
    {
        return await _repository.UpdateAsync(flight);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _repository.DeleteAsync(id);
    }
}
