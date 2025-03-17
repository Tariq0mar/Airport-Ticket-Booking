using System;
using AirportTicketBooking;

namespace AirportTicketBooking;

class Booking
{
    // public record Flight(string Id, decimal Price, class,);
    public required FlightRecord FlightRecord { get; init; }
    public required Passenger PassengerName { get; init; } // or user id 

    public Booking(Flight flight, Passenger passengerName)
    {
        Flight = flight;
        PassengerName = passengerName;
    }
}
