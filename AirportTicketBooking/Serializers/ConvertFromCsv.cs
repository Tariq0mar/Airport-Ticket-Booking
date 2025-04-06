using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;
using AirportTicketBooking.ModelsFactories;
using AirportTicketBooking.Validators;
using System.Globalization;

namespace AirportTicketBooking.Convert;

public class ConvertFromCsv
{
    public static Flight? ToFlight(string line)
    {
        if (!CsvLineValidator.FlightLineValidator(line)){
            return null;
        }

        var parts = line.Split(',');
        var flightId = parts[0];

        var departureData = new TravelData(
            Enum.Parse<Country>(parts[1]),
            DateTime.Parse(parts[2], null, DateTimeStyles.RoundtripKind),
            Enum.Parse<Airport>(parts[3])
        );

        var destinationData = new TravelData(
            Enum.Parse<Country>(parts[4]),
            DateTime.Parse(parts[5], null, DateTimeStyles.RoundtripKind),
            Enum.Parse<Airport>(parts[6])
        );

        var classPrice = new Dictionary<FlightClass, float>();
        int.TryParse(parts[7], out var size);
        for (var i = 1; i <= size; i++)
        {
            var key = Enum.Parse<FlightClass>(parts[4]);
            float.TryParse(parts[i + 8], out var value);
            if (!classPrice.TryAdd(key, value))
            {
                classPrice[key] = value;
            }
        }

        return FlightFactory.CreateFlightFromParameters(flightId, departureData, destinationData, classPrice);
    }

    public static Booking? ToBooking(string line)
    {
        if (!CsvLineValidator.BookingLineValidator(line){
            return null;
        }

        var parts = line.Split(',');
        return BookingFactory.CreateBooking(parts[0], parts[1], parts[2]);
    }

    public static User? ToUser(string line)
    {
        var parts = line.Split(',');

        if (!CsvLineValidator.UserLineValidator(line))
        {
            return null;
        }

        if (line.Length == 5)
        {
            return UserFactory.CreateManager(parts[0], parts[1], parts[2], parts[3], parts[4]);
        }
        else if (line.Length == 6)
        {
            return UserFactory.CreatePassenger(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
        }

        return null;
    }
}