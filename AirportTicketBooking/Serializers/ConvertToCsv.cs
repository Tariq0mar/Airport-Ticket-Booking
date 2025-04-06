using AirportTicketBooking.Models;
using System.Text;

namespace AirportTicketBooking.Serializers;

class ConvertToCsv
{
    public static string FromFlight(Flight flight)
    {
        StringBuilder classes = new StringBuilder();
        foreach (var classPrice in flight.ClassPrice)
        {
            classes.Append(classPrice.Key + "," + classPrice.Value + ",");
        }
        classes.Remove(classes.Length - 1, classes.Length);

        return $"{flight.FlightId},{flight.DepartureData},{flight.DestinationData},{classes}";
    }

    public static string FromBooking(Booking booking)
    {
        return $"{booking.Id},{booking.FlightId},{booking.PassengerId}";
    }
}
