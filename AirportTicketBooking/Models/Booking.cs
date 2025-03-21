using System;
using AirportTicketBooking;
using AirportTicketBooking.Models;

namespace AirportTicketBooking;

public class Booking
{
    public required Flight Flight{ get; init; }
    public required Passenger Passenger { get; init; }

    public Booking(Flight flight, Passenger passenger)
    {
        Flight = flight;
        Passenger = passenger;
    }

    public override string ToString()
    {
        return $"{Flight},{Passenger}";
    }
}
