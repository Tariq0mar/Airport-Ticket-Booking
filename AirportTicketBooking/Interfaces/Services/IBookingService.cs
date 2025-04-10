using AirportTicketBooking.Models;

namespace AirportTicketBooking.Interfaces.Services;

public interface IBookingService
{
    Task AddAsync(Booking booking);
    Task<Booking?> GetAsync(string id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<bool> UpdateAsync(Booking booking);
    Task<bool> DeleteAsync(string id);
}


