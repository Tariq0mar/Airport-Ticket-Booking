using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.FlightActions;

public static class BookingPassengerActions
{
    private static readonly IFlightService _flightService = new FlightService();

    public static async Task GetFlightById()
    {
        Console.WriteLine("Enter Flight ID:");
        var flightId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(flightId) || int.TryParse(flightId, out _))
        {
            Console.WriteLine("Invalid input, try again");
            flightId = Console.ReadLine();
        }

        var flight = await _flightService.GetByIdAsync(flightId);

        Console.WriteLine(flight != null
            ? flight.ToString()
            : "Flight not found.");
    }

    public static async Task GetAllFlights()
    {
        var flights = await _flightService.GetAllAsync();
        foreach (var flight in flights)
        {
            Console.WriteLine(flight.ToString());
        }
    }
}
