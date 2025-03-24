using System;

namespace AirportTicketBooking.Models;

public class Booking
{
    public int Id { get; init; }
    public int FlightId{ get; init; }
    public int PassengerId { get; init; }

    public Booking(int id, int flightId, int passengerId)
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
