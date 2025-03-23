using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Interfaces.Services;

public interface IBookingService
{
    Task AddBookingAsync(Booking booking);
    Task<Booking> GetBookingAsync(int id);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(int id);
    Task<IEnumerable<Booking>> GetAllBookingsAsync();
}


