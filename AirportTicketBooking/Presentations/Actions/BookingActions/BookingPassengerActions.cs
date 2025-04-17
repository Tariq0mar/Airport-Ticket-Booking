using AirportTicketBooking.InputModels.InputBooking;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.BookingActions; 

public class BookingPassengerActions
{
    private readonly IBookingService _bookingService = new BookingService();

    public async Task AddBooking()
    {
        var booking = InputBooking.Input();
        var result = await _bookingService.AddAsync(booking);
        Console.WriteLine($"Booking added with ID: {result}");
    }

    public async Task GetBookingsByPassengerId()
    {
        Console.WriteLine("Enter passenger ID:");
        var passengerId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(passengerId) || !int.TryParse(passengerId, out _))
        {
            Console.WriteLine("invalid input, try again");
            passengerId = Console.ReadLine();
        }

        var bookings = await _bookingService.GetByPassengerIdAsync(passengerId);
        foreach (var booking in bookings)
        {
            Console.WriteLine(booking.ToString());
        }
    }
}
