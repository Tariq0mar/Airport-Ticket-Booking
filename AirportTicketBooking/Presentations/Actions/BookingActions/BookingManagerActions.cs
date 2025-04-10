using AirportTicketBooking.InputModels.InputBooking;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.BookingActions;

public class BookingManagerActions
{
    private readonly IBookingService _bookingService = new BookingService();
    
    public void Add()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("Welcome, to add a new booking please fill the following data");

        var booking = InputBooking.Input();
        _bookingService.AddAsync(booking);
    }

    public void Get()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("Welcome, please enter the id of the wanted booking");

        var id = Console.ReadLine();
        while (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("invalid input, try again");
            id = Console.ReadLine();
        }

        var booking = _bookingService.GetAsync(id);
        if (booking is null)
        {
            Console.WriteLine("These is no booking with similar id");
        }
        else
        {
            Console.WriteLine(booking.ToString());
        }
    }

    //public void GetAll()
    //{
    //}

    public void Update()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("Welcome, please enter the id of the booking you want to update");

        var id = Console.ReadLine();
        while (string.IsNullOrEmpty(id) || _bookingService.GetAsync(id) is null)
        {
            Console.WriteLine("invalid input or not found booking with this id, try again");
            id = Console.ReadLine();
        }

        var inputBooking = InputBooking.Input();
        var newBooking = new Booking
        {
            Id = id,
            FlightId = inputBooking.FlightId,
            PassengerId = inputBooking.PassengerId
        };
        _bookingService.UpdateAsync(newBooking);
    }

    public void Delete()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("Welcome, please enter the id of the booking you want to delete");

        var id = Console.ReadLine();
        while (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("invalid input, try again");
            id = Console.ReadLine();
        }

        _bookingService.DeleteAsync(id);
    }
}
