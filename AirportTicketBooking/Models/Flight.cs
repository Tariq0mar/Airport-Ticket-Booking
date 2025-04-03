using AirportTicketBooking.Enums;
using AirportTicketBooking.InputClasses;
using System.Text;

namespace AirportTicketBooking.Models;

public class Flight
{
    public string FlightId { get; set; }
    public TravelData DepartureData { get; init; }
    public TravelData DestinationData { get; init; }
    public Dictionary<FlightClass, float> ClassPrice { get; init; }

    private Flight(TravelData departureData, TravelData destinationData, Dictionary<FlightClass, float> classPrice)
    {
        DepartureData = departureData;
        DestinationData = destinationData;
        ClassPrice = classPrice;
    }

    public static Flight CreateFlight(string flightId, TravelData departureData, TravelData destinationData, Dictionary<FlightClass, float> classPrice)
    {
        return new Flight(departureData, destinationData, classPrice);
    }

    public static Flight CreateFlight()
    {

        Console.WriteLine($"Welcome, we need some information about the ticket");

        var departureData = InputTravelData.GetTravelData();
        var destinationData = InputTravelData.GetTravelData();
        var classPrice = InputFlightClassPrices.InputClassesPrices();

        return new Flight(departureData, destinationData, classPrice);
    }

    public override string ToString()
    {
        StringBuilder classes = new StringBuilder();
        foreach (var classPrice in ClassPrice)
        {
            classes.Append(classPrice.Key + "," + classPrice.Value + ",");
        }
        classes.Remove(classes.Length - 1, classes.Length);

        return $"{FlightId},{DepartureData},{DestinationData},{classes.Length},{classes}";
    }
}
