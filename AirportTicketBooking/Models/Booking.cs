using System;

namespace AirportTicketBooking.Models;

public class Booking
{
    public required int Id { get; init; }
    public required int FlightId{ get; init; }
    public required int PassengerId { get; init; }

    public Booking(int id, int flightId, int passengerId)
    {
        Id = id;
        FlightId = flightId;
        PassengerId = passengerId;
    }

    public override string ToString()
    {
        return $"{FlightId},{PassengerId}";
    }
}
