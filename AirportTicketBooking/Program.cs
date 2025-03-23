using System;
using AirportTicketBooking;
using AirportTicketBooking.Enums;
using AirportTicketBooking.InputClasses;
using AirportTicketBooking.Models;

namespace AirportTicketBooking;

public class Program
{
    public static void Main(string[] args)
    {
        var x= InputTravelData.GetTravelInformation<DestinationData>();
    }
}


