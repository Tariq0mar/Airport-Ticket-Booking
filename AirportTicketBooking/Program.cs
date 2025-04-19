using AirportTicketBooking.Presentations.Actions.BookingActions;
using AirportTicketBooking.Presentations.Actions.UserActions;
using AirportTicketBooking.Presentations.Screens;

namespace AirportTicketBooking;

public class Program
{
    public static async Task Main(string[] args)
    {
        await UserManagerActions.GetAllUsers();
    }
}


