using AirportTicketBooking.Enums;
using AirportTicketBooking.Presentations.Actions;
using AirportTicketBooking.Presentations.Actions.BookingActions;
using AirportTicketBooking.Presentations.Actions.FlightActions;
using AirportTicketBooking.Presentations.Actions.UserActions;

namespace AirportTicketBooking.Presentations.Menus;

public class AppManagerMenu
{
    public async Task Show()
    {
        while (true)
        {
            Console.WriteLine("--- Manager Menu ---");

            foreach (var option in Enum.GetValues(typeof(ManagerOptions)))
            {
                Console.WriteLine($"{(int)option}. {option}");
            }

            Console.Write("Select an option: ");

            var input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input) && !int.TryParse(input, out _))
            {
                Console.WriteLine("invalid input, try again");
                input = Console.ReadLine();
            }

            var selectedOption = (ManagerOptions)int.Parse(input);

            switch (selectedOption)
            {
                case ManagerOptions.AddUser:
                    await UserManagerActions.AddUser();
                    break;

                case ManagerOptions.GetUserById:
                    await UserManagerActions.GetUserById();
                    break;

                case ManagerOptions.GetUserByEmail:
                    await UserManagerActions.GetUserByEmail();
                    break;

                case ManagerOptions.GetAllUsers:
                    await UserManagerActions.GetAllUsers();
                    break;

                case ManagerOptions.UpdateUser:
                    await UserManagerActions.UpdateUser();
                    break;

                case ManagerOptions.DeleteUser:
                    await UserManagerActions.DeleteUser();
                    break;

                case ManagerOptions.AddBooking:
                    await BookingManagerActions.AddBooking();
                    break;

                case ManagerOptions.GetBookingById:
                    await BookingManagerActions.GetBookingById();
                    break;

                case ManagerOptions.GetBookingByPassengerId:
                    await BookingManagerActions.GetBookingsByPassengerId();
                    break;

                case ManagerOptions.GetAllBookings:
                    await BookingManagerActions.GetAllBookings();
                    break;

                case ManagerOptions.UpdateBooking:
                    await BookingManagerActions.UpdateBooking();
                    break;

                case ManagerOptions.DeleteBooking:
                    await BookingManagerActions.DeleteBooking();
                    break;

                case ManagerOptions.AddFlight:
                    await FlightManagerActions.AddFlight();
                    break;

                case ManagerOptions.GetFlight:
                    await FlightManagerActions.GetFlightById();
                    break;

                case ManagerOptions.GetAllFlights:
                    await FlightManagerActions.GetAllFlights();
                    break;

                case ManagerOptions.UpdateFlights:
                    await FlightManagerActions.UpdateFlight();
                    break;

                case ManagerOptions.DeleteFlights:
                    await FlightManagerActions.DeleteFlight();
                    break;

                case ManagerOptions.Exit:
                    return;

                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }
    }
}
