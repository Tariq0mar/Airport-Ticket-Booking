using AirportTicketBooking.Models;

namespace AirportTicketBooking.ModelsFactories;

class BookingFactory
{
    public static Booking CreateBooking(string id, string flightId, string passengerId)
    {
        var booking = new Booking(flightId, passengerId);
        booking.Id = id;
        return booking;
    }

    public static Booking CreateBooking(string flightId, string passengerId)
    {
        return new Booking(flightId, passengerId);
    }
}
