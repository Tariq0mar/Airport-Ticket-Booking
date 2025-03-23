using AirportTicketBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Models;

public class TravelData
{
    public Country LocationCountry { get; init; }
    public DateTime FlightDate { get; init; }
    public Airport FlightAirport { get; init; }
    public TravelData(Country locationCountry, DateTime flightDate, Airport flightAirport)
    {
        LocationCountry = locationCountry;
        FlightDate = flightDate;
        FlightAirport = flightAirport;
    }

    public override string ToString()
    {
        return $"{LocationCountry},{FlightDate},{FlightAirport}";
    }
}
