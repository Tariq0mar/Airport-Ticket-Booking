using AirportTicketBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.InputClasses;

class InputDepartureInformation
{
    public static DepartureInformation GetDepartureInformation()
    {
        var counrty = InputDepartureCountry();
        var date = InputDepartureDate();
        var airport = InputDepartureAirport();

        return new DepartureInformation(counrty, date, airport);
    }

    private static Country InputDepartureCountry()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Choose the Departure country:");

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
    private static DateTime InputDepartureDate()
    {
        return DateTime.Now;
    }
    private static Airport InputDepartureAirport()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Choose the Departure Airport:");

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
