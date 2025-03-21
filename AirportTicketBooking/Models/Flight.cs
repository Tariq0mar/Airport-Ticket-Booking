using System;
using System.Linq;
using System.Text;
using AirportTicketBooking;
using AirportTicketBooking.Enums;
using AirportTicketBooking.InputClasses;

namespace AirportTicketBooking;

public class Flight
{
    private static int _idCounter = 0;
    public string FlightID { get; init; }
    public DepartureInformation departureInformation;
    public DestinationInformation destinationInformation;
    public Dictionary<FlightClass, float> ClassPrice;

    public Flight()
    {
        FlightID = (++_idCounter).ToString("D11");

        Console.WriteLine($"Welcome, you created flight number ( {FlightID} ) but we still need some information about it");

        ClassPrice = InputFlightClassPrices.InputClassesPrices();
        departureInformation = InputDepartureInformation.GetDepartureInformation();
        destinationInformation = InputDestinationInformation.GetDestinationInformation();
    }

    public override string ToString()
    {
        StringBuilder classes = new StringBuilder();
        foreach (var classPrice in ClassPrice)
        {
            classes.Append(classPrice.Key + "," + classPrice.Value);
        }

        return $"{FlightID},{departureInformation},{destinationInformation},{classes}";
    }
}
