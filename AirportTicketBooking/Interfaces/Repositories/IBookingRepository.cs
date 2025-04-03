using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Repositories;

public interface IBookingRepository
{
    Task AddBookingAsync(Booking booking);
    Task<Booking?> GetBookingByIdAsync(string id);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(string id);
    Task<IEnumerable<Booking>> GetAllBookingsAsync();
}