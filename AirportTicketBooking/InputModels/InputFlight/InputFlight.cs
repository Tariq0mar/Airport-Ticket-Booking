using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.InputModels.InputFlight;

public class InputFlight
{
    public static Flight Input()
    {
        var flight = new Flight {
            FlightId = string.Empty,
            DepartureData = InputFlightTravelData.Input(1),
            DestinationData = InputFlightTravelData.Input(2),
            ClassPrice = InputFlightClassPrices.Input()
        };

        return flight;
    }
}
