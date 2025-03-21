using System;
using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.InputClasses;

class InputDestinationInformation
{
    public static DestinationInformation GetDestinationInformation()
    {
        var counrty = InputDestinationCountry();
        var date = InputDestinationDate();
        var airport = InputDestinationAirport();

        return new DestinationInformation(counrty, date, airport);
    }

    private static Country InputDestinationCountry()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Choose the destination country:");

        var countries = Enum.GetValues<Country>().ToArray();

        for (int i = 0; i < countries.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {countries[i]}");
        }

        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out int index) &&
                index > 0 && index <= countries.Length)
            {
                return countries[index - 1];
            }

            Console.WriteLine("Invalid input. Please enter a valid number from the list.");
        }
    }
    private static DateTime InputDestinationDate()
    {
        return DateTime.Now;
    }
    private static Airport InputDestinationAirport()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Choose the destination Airport:");

        var airport = Enum.GetValues<Airport>().ToArray();

        for (int i = 0; i < airport.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {airport[i]}");
        }

        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out int index) &&
                index > 0 && index <= airport.Length)
            {
                return airport[index - 1];
            }

            Console.WriteLine("Invalid input. Please enter a valid number from the list.");
        }
    }
}
