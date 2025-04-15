using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Repositories;

public interface IBookingRepository
{
    Task<bool> AddAsync(Booking booking);
    Task<Booking?> GetByBookingIdAsync(string id);
    Task<IEnumerable<Booking>> GetByPassengerIdAsync(string id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<bool> UpdateAsync(Booking booking);
    Task<bool> DeleteAsync(string id);
}