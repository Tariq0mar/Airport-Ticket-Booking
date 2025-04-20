using AirportTicketBooking.Enums;
using AirportTicketBooking.Presentations.Menus;


namespace AirportTicketBooking.Presentations.Screens;

public static class PassengerDashboardScreen
{
    private static readonly AppPassengerMenu _menu = new AppPassengerMenu();

    public static async Task PassengerScreen()
    {
        while (true)
        {
            Console.WriteLine("Enter 1 if want to open the actions menu\n"
                              + "Enter 2 if want to logout");

            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number is not (1 or 2))
            {
                Console.WriteLine("invalid input, try again");
            }

            switch (number)
            {
                case 1:
                    await _menu.Show();
                    break;
                case 2:
                    return;
            }
        }
    }
}
