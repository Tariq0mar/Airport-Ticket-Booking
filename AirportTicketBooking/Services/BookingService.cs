using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;

    public BookingService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> AddAsync(Booking booking)
    {
        return await _repository.AddAsync(booking);
    }

    public async Task<Booking?> GetByBookingIdAsync(string id)
    {
        return await _repository.GetByBookingIdAsync(id);
    }

    public async Task<IEnumerable<Booking>> GetByPassengerIdAsync(string id)
    {
        return await _repository.GetByPassengerIdAsync(id);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> UpdateAsync(Booking booking)
    {
        return await _repository.UpdateAsync(booking);
    }
}