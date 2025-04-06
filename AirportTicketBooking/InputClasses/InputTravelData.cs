using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.InputClasses;

public class InputTravelData
{
    public static TravelData GetTravelData()
    {
        const int departureNumber = 1;
        const int destinationNumber = 2;

        var place = string.Empty;
        Console.WriteLine($"press {departureNumber} if you want to input depature data");
        Console.WriteLine($"press {destinationNumber} if you want to input destination data");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var index) && (index == departureNumber || index == destinationNumber))
            {
                place = index == departureNumber ? "depature" : "destination";
                break;
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

        for (var i = 0; i < countries.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {countries[i]}");
        }

        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out var index) &&
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

        for (var i = 0; i < airport.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {airport[i]}");
        }

        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out var index) &&
                index > 0 && index <= airport.Length)
            {
                return airport[index - 1];
            }

            Console.WriteLine("Invalid input. Please enter a valid number from the list.");
        }
    }
}
