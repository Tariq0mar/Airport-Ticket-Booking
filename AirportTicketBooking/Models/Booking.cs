namespace AirportTicketBooking.Models;

public class Booking
{
    public required string Id { get; init; } = string.Empty;
    public required string FlightId { get; init; }
    public required string PassengerId { get; init; }
}
