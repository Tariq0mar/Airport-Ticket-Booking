using AirportTicketBooking.Models;

namespace AirportTicketBooking.Presentations.Screens;

class UserLoginScreen
{
    public static async Task Login()
    {
        var user = await InputAccountData.InputUserAccountData();

        if (user is Passenger)
        {
            Console.WriteLine($"Welcome passenger {user.Name}");
            await PassengerDashboardScreen.PassengerScreen();
        }
        else if (user is Manager)
        {
            Console.WriteLine($"Welcome Manager {user.Name}");
            await ManagerDashboardScreen.ManagerScreen();
        }
    }
}
