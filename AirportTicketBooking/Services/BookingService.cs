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

    public Task AddAsync(Booking booking)
    {
        return _repository.AddAsync(booking);
    }

    public Task DeleteAsync(string id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<Booking?> GetAsync(string id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task UpdateAsync(Booking booking)
    {
        return _repository.UpdateAsync(booking);
    }
}
