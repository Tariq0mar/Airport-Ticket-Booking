using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IBookingService
{
    Task AddAsync(Booking booking);
    Task<Booking?> GetByBookingIdAsync(string id);
    Task<IEnumerable<Booking>> GetByPassengerIdAsync(string id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(string id);
}