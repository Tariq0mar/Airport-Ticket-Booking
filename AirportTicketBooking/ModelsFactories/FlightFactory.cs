using AirportTicketBooking.Enums;
using AirportTicketBooking.InputClasses;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.ModelsFactories;

class FlightFactory
{
    public static Flight CreateFlightFromParameters(string flightId, TravelData departureData, TravelData destinationData, Dictionary<FlightClass, float> classPrice)
    {
        return new Flight(flightId, departureData, destinationData, classPrice);
    }

    public static Flight CreateFlightFromUserInput()
    {

        Console.WriteLine($"Welcome, we need some information about the ticket");

        var departureData = InputTravelData.GetTravelData();
        var destinationData = InputTravelData.GetTravelData();
        var classPrice = InputFlightClassPrices.InputClassesPrices();

        return new Flight(string.Empty, departureData, destinationData, classPrice);
    }
}
