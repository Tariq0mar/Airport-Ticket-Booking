using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;
using System.Globalization;

namespace AirportTicketBooking.Convert;

public class ConvertFromCsv
{
    public static Flight ToFlight(string line)
    {
        var parts = line.Split(',');

        var flightId = parts[0];
        var departureData = new TravelData(Enum.Parse<Country>(parts[1]),
                                           DateTime.Parse(parts[2], null, DateTimeStyles.RoundtripKind),
                                           Enum.Parse<Airport>(parts[3]));

        var destinationData = new TravelData(Enum.Parse<Country>(parts[4]),
                                             DateTime.Parse(parts[5], null, DateTimeStyles.RoundtripKind),
                                             Enum.Parse<Airport>(parts[6]));

        Dictionary<FlightClass, float> classPrice = new Dictionary<FlightClass, float>();
        int.TryParse(parts[7], out int size);
        for (int i = 1; i <= size; i++)
        {
            FlightClass key = Enum.Parse<FlightClass>(parts[4]);
            int.TryParse(parts[i + 8], out int value);
            classPrice[key] = value;
        }

        return Flight.CreateFlight(flightId, departureData, destinationData, classPrice);
    }
}