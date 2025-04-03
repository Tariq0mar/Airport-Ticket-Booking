using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking.Services;

class BookingService : IBookingService
{
    private IBookingRepository _repository;

    public BookingService()
    {
        _repository = new BookingRepository();
    }

    public Task AddBookingAsync(Booking booking)
    {
        return _repository.AddBookingAsync(booking);
    }

    public Task DeleteBookingAsync(string id)
    {
        return _repository.DeleteBookingAsync(id);
    }

    public Task<Booking?> GetBookingAsync(string id)
    {
        return _repository.GetBookingByIdAsync(id);
    }

    public Task UpdateBookingAsync(Booking booking)
    {
        return _repository.UpdateBookingAsync(booking);
    }
}
