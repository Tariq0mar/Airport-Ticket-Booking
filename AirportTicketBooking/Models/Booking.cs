namespace AirportTicketBooking.Models;

public class Booking
{
    public string Id { get; set; }
    public string FlightId { get; set; }
    public string PassengerId { get; set; }

    public Booking(string flightId, string passengerId)
    {
        FlightId = flightId;
        PassengerId = passengerId;
    }
    public Booking(string id, string flightId, string passengerId) : this(flightId, passengerId)
    {
        Id = id;
        FlightId = flightId;
        PassengerId = passengerId;
    }

    public override string ToString()
    {
        return $"{Id},{FlightId},{PassengerId}";
    }
}
