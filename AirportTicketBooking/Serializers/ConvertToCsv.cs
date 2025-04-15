using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Serializers;

class ConvertToCsv
{
    public static string FromFlight(Flight flight)
    {
        var departure = $"{flight.DepartureData.LocationCountry},{flight.DepartureData.FlightAirport},{flight.DepartureData.FlightDate}";
        var destination = $"{flight.DestinationData.LocationCountry},{flight.DestinationData.FlightAirport},{flight.DestinationData.FlightDate}";

        var classes = string.Join(",", flight.ClassPrice.Select(c => $"{c.Key},{c.Value}"));

        return $"{flight.FlightId},{departure},{destination},{classes}";
    }

    public static string FromBooking(Booking booking)
    {
        return $"{booking.Id},{booking.FlightId},{booking.PassengerId}";
    }

    public static string FromUser(User user)
    {
        if (user.Role == UserRole.Passenger)
        {
            var passenger = (Passenger)(user);
            return FromUser(passenger);
        }
        else
        {
            var manager = (Manager)(user);
            return FromUser(manager);
        }
    }
    private static string FromUser(Manager manager)
    {
        return $"{manager.UserId},{manager.Role},{manager.Name},{manager.Email},{manager.Password},{manager.PhoneNumber}";
    }
    private static string FromUser(Passenger passenger)
    {
        return $"{passenger.UserId},{passenger.Role},{passenger.Name},{passenger.Email},{passenger.Password},{passenger.PhoneNumber},{passenger.PassportNumber}";
    }
}
