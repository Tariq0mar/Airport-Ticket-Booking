using System;
using AirportTicketBooking;

namespace AirportTicketBooking.AirportTicketBooking;

class DestinationInformation
{
    public required string DestinationCountry { get; init; }
    public required DateTime DestinationDate { get; init; }
    public required string DestinationAirport { get; init; }
    public DestinationInformation(string destinationCountry, DateTime destinationDate, string destinationAirport)
    {
        DestinationCountry = destinationCountry;
        DestinationDate = destinationDate;
        DestinationAirport = destinationAirport;
    }
}
