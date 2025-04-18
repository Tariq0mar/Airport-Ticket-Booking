using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.UserActions;

public static class UserPassengerActions
{
    private static readonly IUserService _userService = new UserService();

    public static async Task GetUserById()
    {
        Console.WriteLine("Enter User ID:");
        var userId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(userId) || int.TryParse(userId, out _))
        {
            Console.WriteLine("Invalid input, try again");
            userId = Console.ReadLine();
        }

        var user = await _userService.GetByIdAsync(userId);

        Console.WriteLine(user != null
            ? user.ToString()
            : "User not found.");
    }
}
