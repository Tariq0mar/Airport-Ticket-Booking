using AirportTicketBooking.InputModels.InputBooking;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.BookingActions;

public class BookingManagerActions
{
    private readonly IBookingService _bookingService = new BookingService();
    
    
}
