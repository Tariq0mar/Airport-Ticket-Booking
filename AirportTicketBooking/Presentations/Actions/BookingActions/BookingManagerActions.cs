using AirportTicketBooking.InputModels.InputBooking;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.BookingActions;

public static class BookingManagerActions
{
    private static readonly IBookingService _bookingService = new BookingService(new BookingRepository());

    public static async Task AddBooking()
    {
        var booking = InputBooking.Input();
        var result = await _bookingService.AddAsync(booking);
        Console.WriteLine($"Booking added with ID: {result}");
    }

    public static async Task GetBookingById()
    {
        Console.WriteLine("Enter Booking ID:");
        var bookingId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(bookingId) || !int.TryParse(bookingId, out _))
        {
            Console.WriteLine("invalid input, try again");
            bookingId = Console.ReadLine();
        }

        var booking = await _bookingService.GetByBookingIdAsync(bookingId);
        Console.WriteLine(booking != null
                          ? booking.ToString()
                          : "Booking not found.");
    }

    public static async Task GetBookingsByPassengerId()
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

    public static async Task GetAllBookings()
    {
        var bookings = await _bookingService.GetAllAsync();
        foreach (var booking in bookings)
        {
            Console.WriteLine(booking.ToString());
        }
    }

    public static async Task UpdateBooking()
    {
        Console.WriteLine("Enter Booking ID:");
        var bookingId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(bookingId) || !int.TryParse(bookingId, out _))
        {
            Console.WriteLine("invalid input, try again");
            bookingId = Console.ReadLine();
        }

        var existingBooking = await _bookingService.GetByBookingIdAsync(bookingId);

        if (existingBooking is not null)
        {
            var booking = InputBooking.Input();

            var newBooking = new Booking
            {
                Id = existingBooking.Id,
                FlightId = booking.FlightId,
                PassengerId = booking.PassengerId
            };

            var success = await _bookingService.UpdateAsync(newBooking);
            Console.WriteLine(success ? "Booking updated successfully." : "Failed to update booking.");
        }
        else
        {
            Console.WriteLine("Booking not found.");
        }

        Console.ReadLine();
    }

    public static async Task DeleteBooking()
    {
        Console.WriteLine("Enter Booking ID:");
        var bookingId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(bookingId) || !int.TryParse(bookingId, out _))
        {
            Console.WriteLine("invalid input, try again");
            bookingId = Console.ReadLine();
        }

        var success = await _bookingService.DeleteAsync(bookingId);
        Console.WriteLine(success ? "Booking deleted successfully." : "Failed to delete booking.");
    }
}
