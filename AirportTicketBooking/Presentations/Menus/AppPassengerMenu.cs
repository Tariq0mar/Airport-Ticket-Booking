using AirportTicketBooking.Enums;
using AirportTicketBooking.Presentations.Actions.BookingActions;
using AirportTicketBooking.Presentations.Actions.FlightActions;
using AirportTicketBooking.Presentations.Actions.UserActions;

namespace AirportTicketBooking.Presentations.Menus;

public class AppPassengerMenu
{
    public async Task Show()
    {
        while (true)
        {
            Console.WriteLine("--- Manager Menu ---");

            foreach (var option in Enum.GetValues(typeof(PassengerOptions)))
            {
                Console.WriteLine($"{(int)option}. {option}");
            }

            Console.Write("Select an option: ");

            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("invalid input, try again");
            }

            var selectedOption = (PassengerOptions)number;

            switch (selectedOption)
            {
                case PassengerOptions.GetUserData:
                    await UserPassengerActions.GetUserById();
                    break;

                case PassengerOptions.GetFlight:
                    await FlightPassengerActions.GetFlightById();
                    break;

                case PassengerOptions.GetAllFlights:
                    await FlightPassengerActions.GetAllFlights();
                    break;

                case PassengerOptions.BookFlight:
                    await BookingPassengerActions.AddBooking();
                    break;

                case PassengerOptions.MyBookings:
                    await BookingPassengerActions.GetBookingsByPassengerId();
                    break;

                case PassengerOptions.Exit:
                    return;

                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }
    }
}
