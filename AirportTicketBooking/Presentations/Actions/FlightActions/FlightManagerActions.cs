using AirportTicketBooking.InputModels.InputFlight;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.FlightActions;

public class FlightManagerActions
{
    private readonly IFlightService _flightService = new FlightService();

    public async Task AddFlight()
    {
        var flight = InputFlight.Input();
        var result = await _flightService.AddAsync(flight);
        Console.WriteLine($"Flight added with ID: {result}");
    }

    public async Task GetFlightById()
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

    public async Task GetAllFlights()
    {
        var flights = await _flightService.GetAllAsync();
        foreach (var flight in flights)
        {
            Console.WriteLine(flight.ToString());
        }
    }

    public async Task UpdateFlight()
    {
        Console.WriteLine("Enter Flight ID:");
        var flightId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(flightId) || int.TryParse(flightId, out _))
        {
            Console.WriteLine("Invalid input, try again");
            flightId = Console.ReadLine();
        }

        var existingFlight = await _flightService.GetByIdAsync(flightId);

        if (existingFlight is not null)
        {
            var flight = InputFlight.Input();

            var updatedFlight = new Flight
            {
                FlightId = existingFlight.FlightId,
                DepartureData = flight.DepartureData,
                DestinationData = flight.DestinationData,
                ClassPrice = flight.ClassPrice
            };

            var success = await _flightService.UpdateAsync(updatedFlight);
            Console.WriteLine(success ? "Flight updated successfully." : "Failed to update flight.");
        }
        else
        {
            Console.WriteLine("Flight not found.");
        }
    }

    public async Task DeleteFlight()
    {
        Console.WriteLine("Enter Flight ID:");
        var flightId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(flightId) || int.TryParse(flightId, out _))
        {
            Console.WriteLine("Invalid input, try again");
            flightId = Console.ReadLine();
        }

        var success = await _flightService.DeleteAsync(flightId);
        Console.WriteLine(success ? "Flight deleted successfully." : "Failed to delete flight.");
    }
}
