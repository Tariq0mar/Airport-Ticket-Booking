using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.InputClasses;

public class InputTravelData
{
    public static TravelData GetTravelData()
    {
        string place = string.Empty;
        Console.WriteLine("press 1 if you want to input depature data");
        Console.WriteLine("press 2 if you want to input destination data");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int index) && (index == 1 || index == 2))
            {
                if(index == 1)
                {
                    place = "depature";
                }
                else
                {
                    place = "destination";
                }
            }
            else
            {
                Console.WriteLine("invalid input, press 1 or 2");
            }
        }

        var counrty = InputCountry(place);
        var date = InputDate(place);
        var airport = InputAirport(place);

        return new TravelData(counrty, date, airport);
    }

    private static Country InputCountry(string place)
    {
        Console.WriteLine("==============================");
        Console.WriteLine($"Choose the {place} country:");

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
    private static DateTime InputDate(string place)
    {
        return DateTime.Now;
    }
    private static Airport InputAirport(string place)
    {
        Console.WriteLine("==============================");
        Console.WriteLine($"Choose the {place} Airport:");

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
