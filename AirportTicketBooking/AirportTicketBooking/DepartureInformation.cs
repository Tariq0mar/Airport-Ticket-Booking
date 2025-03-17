using System;
using AirportTicketBooking;

namespace AirportTicketBooking.AirportTicketBooking;

class DepartureInformation
{
    public required string DepartureCountry { get; init; }
    public required DateTime DepartureDate { get; init; }
    public required string DepartureAirport { get; init; }
    public DepartureInformation(string departureCountry, DateTime departureDate, string departureAirport)
    {
        DepartureCountry = departureCountry;
        DepartureDate = departureDate;
        DepartureAirport = departureAirport;
    }
}
