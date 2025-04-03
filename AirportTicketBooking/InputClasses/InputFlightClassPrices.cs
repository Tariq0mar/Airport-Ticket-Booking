using AirportTicketBooking.Enums;

namespace AirportTicketBooking.InputClasses;

class InputFlightClassPrices
{
    public static Dictionary<FlightClass, float> InputClassesPrices()
    {
        Console.WriteLine("===============================");
        Console.WriteLine("Please, fill the price for each flight class as positive value \n or enter 0 if you don't have this class \n");
        var prices = new Dictionary<FlightClass, float>();

        foreach (var flightClass in Enum.GetValues<FlightClass>())
        {
            float price;
            Console.Write($"Enter ticket price for class \" {flightClass} \" : ");
            while (!float.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.Write("Invalid input. Enter a valid price: ");
            }
            if (price > 0)
                prices[flightClass] = price;
        }

        return prices;
    }
}
