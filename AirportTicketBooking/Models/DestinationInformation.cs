using System;
using AirportTicketBooking;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking;

public class DestinationInformation
{
    public Country DestinationCountry { get; init; }
    public DateTime DestinationDate { get; init; }
    public Airport DestinationAirport { get; init; }
    public DestinationInformation(Country destinationCountry, DateTime destinationDate, Airport destinationAirport)
    {
        DestinationCountry = destinationCountry;
        DestinationDate = destinationDate;
        DestinationAirport = destinationAirport;
    }

    public override string ToString()
    {
        return $"{DestinationAirport},{DestinationDate},{DestinationAirport}";
    }
}
