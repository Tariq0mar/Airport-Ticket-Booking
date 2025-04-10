using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models;

public class TravelData
{
    public required Country LocationCountry { get; init; }
    public required Airport FlightAirport { get; init; }
    public required DateTime FlightDate { get; init; }
    public override string ToString()
    {
        return $"{LocationCountry},{FlightDate},{FlightAirport}";
    }
}
