using System;
using AirportTicketBooking;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking;

public class DepartureInformation
{
    public Country DepartureCountry { get; init; }
    public DateTime DepartureDate { get; init; }
    public Airport DepartureAirport { get; init; }
    public DepartureInformation(Country departureCountry, DateTime departureDate, Airport departureAirport)
    {
        DepartureCountry = departureCountry;
        DepartureDate = departureDate;
        DepartureAirport = departureAirport;
    }

    public override string ToString()
    {
        return $"{DepartureAirport},{DepartureDate},{DepartureAirport}";
    }
}