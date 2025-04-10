
namespace AirportTicketBooking.Models;

public class Booking
{
    public required string Id { get; init; }
    public required string FlightId { get; init; }
    public required string PassengerId { get; init; }

    public override string ToString()
    {
        return $"Booking ID: {Id}\n" +
               $"Flight ID: {FlightId}\n" +
               $"Passenger ID: {PassengerId}";
    }
}
