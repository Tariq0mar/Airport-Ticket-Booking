using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository = new BookingRepository();

    public async Task AddAsync(Booking booking)
    {
        await _repository.AddAsync(booking);
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

    public async Task DeleteAsync(string id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Booking booking)
    {
        await _repository.UpdateAsync(booking);
    }
}