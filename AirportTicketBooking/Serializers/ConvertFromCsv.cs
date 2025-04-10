using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;
using AirportTicketBooking.Validators;
using System.Globalization;

namespace AirportTicketBooking.Convert;

public class ConvertFromCsv
{
    public static Flight? ToFlight(string line)
    {
        if (!CsvLineValidator.FlightLineValidator(line))
        {
            return null;
        }

        var parts = line.Split(',');
        var flightId = parts[0];

        var departureData = new TravelData
        {
            LocationCountry = Enum.Parse<Country>(parts[1]),
            FlightDate = DateTime.Parse(parts[2], null, DateTimeStyles.RoundtripKind),
            FlightAirport = Enum.Parse<Airport>(parts[3])
        };

        var destinationData = new TravelData
        {
            LocationCountry = Enum.Parse<Country>(parts[4]),
            FlightDate = DateTime.Parse(parts[5], null, DateTimeStyles.RoundtripKind),
            FlightAirport = Enum.Parse<Airport>(parts[6])
        };

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

        var flight = new Flight
        {
            FlightId = string.Empty,
            ClassPrice = classPrice,
            DepartureData = departureData,
            DestinationData = departureData
        };
        return flight;
    }

    public static Booking? ToBooking(string line)
    {
        if (!CsvLineValidator.BookingLineValidator(line))
        {
            return null;
        }

        var parts = line.Split(',');
        var booking = new Booking
        {
            Id = parts[0],
            FlightId = parts[1],
            PassengerId = parts[2]
        };
        return booking;
    }

    public static User? ToUser(string line)
    {
        var parts = line.Split(',');

        if (!CsvLineValidator.UserLineValidator(line))
        {
            return null;
        }

        if (Enum.Parse<UserRole>(parts[1]) == UserRole.Manager)
        {
            return new Manager
            {
                UserId = parts[0],
                Role = Enum.Parse<UserRole>(parts[1]), 
                Name = parts[2], 
                Email = parts[3],
                Password = parts[4],
                PhoneNumber = parts[5]
            };
        }
        else if (Enum.Parse<UserRole>(parts[1]) == UserRole.Passenger)
        {
            return new Passenger
            {
                UserId = parts[0],
                Role = Enum.Parse<UserRole>(parts[1]),
                Name = parts[2],
                Email = parts[3],
                Password = parts[4],
                PhoneNumber = parts[5],
                PassportNumber = parts[6]
            };
        }

        return null;
    }
}