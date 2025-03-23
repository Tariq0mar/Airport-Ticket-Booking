using System;
using System.Text;
using AirportTicketBooking.Enums;
using AirportTicketBooking.InputClasses;

namespace AirportTicketBooking.Models;

public class Flight
{
    private static int _idCounter = 0;
    public string FlightID { get; init; }
    public TravelData DepartureData;
    public TravelData DestinationData;
    public Dictionary<FlightClass, float> ClassPrice;

    private Flight(string flightID, TravelData departureData, TravelData destinationData, Dictionary<FlightClass, float> classPrice)
    {
        FlightID = flightID;
        DepartureData = departureData;
        DestinationData = destinationData;
        ClassPrice = classPrice;
    }

    public static Flight CreateFlight()
    {
        var flightID = (++_idCounter).ToString("D11");

        Console.WriteLine($"Welcome, you created flight number ( {flightID} ) but we still need some information about it");

        var departureData = InputTravelData.GetTravelData();
        var destinationData = InputTravelData.GetTravelData();
        var classPrice = InputFlightClassPrices.InputClassesPrices();
        
        return new Flight(flightID, departureData, destinationData, classPrice);
    }

    public override string ToString()
    {
        StringBuilder classes = new StringBuilder();
        foreach (var classPrice in ClassPrice)
        {
            classes.Append(classPrice.Key + "," + classPrice.Value);
        }

        return $"{FlightID},{DepartureData},{DestinationData},{classes}";
    }
}
