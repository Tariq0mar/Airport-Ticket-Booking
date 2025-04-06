using AirportTicketBooking.Enums;
using AirportTicketBooking.Services;
using AirportTicketBooking.Repositories;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Logging;

class ManagerDashboardView
{
    private readonly UserService _userService = new UserService();
    private readonly BookingService _bookingService = new BookingService();
    private readonly FlightService _flightService = new FlightService();

    private readonly Dictionary<ManagerOptions, Func<Task>> _managerActions;

    public ManagerDashboardView()
    {
        _managerActions = new Dictionary<ManagerOptions, Func<Task>>
        {
            { ManagerOptions.GetUser,       () => _userService.GetUserByIdAsync() },
            { ManagerOptions.UpdateUser,    () => _userService.UpdateUserAsync() },
            { ManagerOptions.DeleteUser,    () => _userService.RemoveUserAsync() },

            { ManagerOptions.GetFligth,     () => _flightService.GetFlightByIdAsync() },
            { ManagerOptions.UpdateFlights, () => _flightService.UpdateFlightAsync() },
            { ManagerOptions.DeleteFlights, () => _flightService.DeleteFlightAsync() },

            { ManagerOptions.GetBooking,    () => _bookingService.GetBookingAsync() },
            { ManagerOptions.UpdateBooking, () => _bookingService.UpdateBookingAsync() },
            { ManagerOptions.DeleteBooking, () => _bookingService.DeleteBookingAsync() }
        };
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("=== Maneger Actions Menu ===");
            foreach (var option in Enum.GetValues(typeof(ManagerOptions)))
            {
                Console.WriteLine($"{(int)option}. {option}");
            }

            Console.WriteLine("Enter option number: ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || !Enum.IsDefined(typeof(ManagerOptions), input))
            {
                Console.WriteLine("Invalid choice, please enter number in the range of actions menu");
            }

            var selected = (ManagerOptions)input;

            if (selected == ManagerOptions.Exit)
            {
                break;
            }

            if (_managerActions.TryGetValue(selected, out var action))
            {
                await action();
            }
            else
            {
                Console.WriteLine("Action is Not Found ):");
            }
        }
    }

    private async Task GetUserAsync()
    {
        Console.Write("Enter user ID: ");
        var id = Console.ReadLine();
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) Console.WriteLine("User not found.");
        else Console.WriteLine($"User Found: {user.Name} ({user.Id})");
    }

    private async Task DeleteUserAsync()
    {
        Console.Write("Enter user ID to delete: ");
        var id = Console.ReadLine();
        await _userService.RemoveUserAsync(id);
        Console.WriteLine("User deleted.");
    }

    private async Task UpdateUserAsync()
    {
        Console.Write("Enter user ID to update: ");
        var id = Console.ReadLine();
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.Write("Enter new name: ");
        user.Name = Console.ReadLine();

        Console.Write("Enter new password: ");
        user.Password = Console.ReadLine();

        await _userService.UpdateUserAsync(user);
        Console.WriteLine("User updated.");
    }

    private async Task GetBookingAsync()
    {
        Console.Write("Enter booking ID: ");
        var id = Console.ReadLine();
        var booking = await _bookingService.GetBookingAsync(id);
        if (booking == null) Console.WriteLine("Booking not found.");
        else Console.WriteLine($"Booking Found: {booking.Id} for User {booking.UserId}");
    }

    private async Task DeleteBookingAsync()
    {
        Console.Write("Enter booking ID to delete: ");
        var id = Console.ReadLine();
        await _bookingService.DeleteBookingAsync(id);
        Console.WriteLine("Booking deleted.");
    }

    private async Task UpdateBookingAsync()
    {
        Console.Write("Enter booking ID to update: ");
        var id = Console.ReadLine();
        var booking = await _bookingService.GetBookingAsync(id);
        if (booking == null)
        {
            Console.WriteLine("Booking not found.");
            return;
        }

        Console.Write("Enter new Flight ID: ");
        booking.FlightId = Console.ReadLine();

        await _bookingService.UpdateBookingAsync(booking);
        Console.WriteLine("Booking updated.");
    }

    private async Task GetFlightAsync()
    {
        Console.Write("Enter flight ID: ");
        var id = Console.ReadLine();
        var flight = await _flightService.GetFlightByIdAsync(id);
        if (flight == null) Console.WriteLine("Flight not found.");
        else Console.WriteLine($"Flight: {flight.Id} - {flight.Departure} -> {flight.Arrival}");
    }

    private async Task DeleteFlightAsync()
    {
        Console.Write("Enter flight ID to delete: ");
        var id = Console.ReadLine();
        await _flightService.DeleteFlightAsync(id);
        Console.WriteLine("Flight deleted.");
    }

    private async Task UpdateFlightAsync()
    {
        Console.Write("Enter flight ID to update: ");
        var id = Console.ReadLine();
        var flight = await _flightService.GetFlightByIdAsync(id);
        if (flight == null)
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Enter new departure: ");
        flight.DepartureData = Console.ReadLine();

        Console.Write("Enter new arrival: ");
        flight.Arrival = Console.ReadLine();

        await _flightService.UpdateFlightAsync(flight);
        Console.WriteLine("Flight updated.");
    }
}
