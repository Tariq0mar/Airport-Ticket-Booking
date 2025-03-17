using System;
using AirportTicketBooking;

namespace AirportTicketBooking;

class Flight
{

    public required string FlightID { get; init; }

    // we need dictionary [class,price]  and class is enum
    public required decimal Price { get; init; }
    public required string Class { get; init; }
    public required int AvailableSeats { get; init; }


    public Flight(string flightID, decimal price, string departureCountry, string destinationCountry,
                  DateTime departureDate, string departureAirport, string arrivalAirport, string flightClass, int availableSeats)
    {
        FlightID = flightID;
        Price = price;
        DepartureCountry = departureCountry;
        DestinationCountry = destinationCountry;
        DepartureDate = departureDate;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;
        Class = flightClass;
        AvailableSeats = availableSeats;
    }
}
