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

    public Flight(string flightId, TravelData departureData, TravelData destinationData, Dictionary<FlightClass, float> classPrice)
    {
        FlightId = flightId;
        DepartureData = departureData;
        DestinationData = destinationData;
        ClassPrice = classPrice;
    }
}
