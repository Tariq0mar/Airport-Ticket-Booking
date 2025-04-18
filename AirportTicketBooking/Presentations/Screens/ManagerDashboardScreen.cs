using AirportTicketBooking.Enums;
using AirportTicketBooking.Presentations.Menus;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Screens;

public static class ManagerDashboardScreen
{
    private static readonly AppManagerMenu _menu = new AppManagerMenu();

    public static void ManagerScreen()
    {
        while (true)
        {
            Console.WriteLine("Enter 1 if want to open the actions menu"
                            + "Enter 2 if want to logout");

            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number is not 1 or 2)
            {
                Console.WriteLine("invalid input, try again");
            }

            switch (number)
            {
                case 1:
                    _menu.Show();
                    break;
                case 2:
                    return;
            }
        }
    }
}
