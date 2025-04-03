using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IBookingService
{
    Task AddBookingAsync(Booking booking);
    Task<Booking?> GetBookingAsync(string id);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(string id);
}


