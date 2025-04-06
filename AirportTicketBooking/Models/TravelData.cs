using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models;

public class TravelData
{
    public Country LocationCountry { get; set; }
    public DateTime FlightDate { get; set; }
    public Airport FlightAirport { get; set; }
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
