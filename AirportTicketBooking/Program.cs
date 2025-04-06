using AirportTicketBooking.Models;
using AirportTicketBooking.Repositories;

namespace AirportTicketBooking;

public class Program
{
    public static void Main(string[] args)
    {
        fun();
    }
    public static async void fun()
    {
        var x = new BookingRepository();

        await x.AddBookingAsync(new Booking(1, 1, 1));

    }
}


