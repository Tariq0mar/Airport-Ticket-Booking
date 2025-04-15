using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models;

public class Flight
{
    public required string FlightId { get; init; }
    public required TravelData DepartureData { get; init; }
    public required TravelData DestinationData { get; init; }
    public required Dictionary<FlightClass, float> ClassPrice { get; init; }

    public override string ToString()
    {
        var classPricesFormatted = string.Join("\n",
            ClassPrice.Select(c => $"{c.Key}: ${c.Value}"));

        return $"Flight ID: {FlightId}\n" +
               $"Departure Data: {DepartureData}\n" +
               $"Destination Data: {DestinationData}\n" +
               $"Class Prices:\n{classPricesFormatted}";
    }
}
