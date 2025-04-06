using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Logging;

class PassengerDashboardView
{
    public static void Menu()
    {
        Console.WriteLine("Actions list:");
        foreach (var option in Enum.GetValues(typeof(PassengerOptions)))
        {
            Console.WriteLine($"{(int)option} - {option}");
        }

        while (true)
        {
            int number;
            Console.Write($"Enter number of option you want");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid input. Enter a valid number from the list");
            }
        }
    }
}
