using AirportTicketBooking.Models;

namespace AirportTicketBooking.InputModels.InputBooking;

public static class InputBooking
{
    public static Booking Input()
    {
        Console.WriteLine("Enter Id number of the Flight ");

        var flightId = Console.ReadLine();
        while (string.IsNullOrEmpty(flightId))
        {
            flightId = Console.ReadLine();
        }

        Console.WriteLine("Enter Id number of the passenger ");

        var passengerId = Console.ReadLine();
        while (string.IsNullOrEmpty(passengerId))
        {
            passengerId = Console.ReadLine();
        }

        var booking = new Booking
        {
            Id = string.Empty,
            FlightId = flightId,
            PassengerId =passengerId
        };

        return booking;
    }
}
