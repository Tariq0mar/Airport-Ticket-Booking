namespace AirportTicketBooking.Models;

public class Booking
{
    public string Id { get; set; }
    public string FlightId { get; set; }
    public string PassengerId { get; set; }

    public Booking(string flightId, string passengerId)
    {
        Id = string.Empty;
        FlightId = flightId;
        PassengerId = passengerId;
    }
}
