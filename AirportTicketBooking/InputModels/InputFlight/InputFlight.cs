using AirportTicketBooking.Models;

namespace AirportTicketBooking.InputModels.InputFlight;

public static class InputFlight
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
