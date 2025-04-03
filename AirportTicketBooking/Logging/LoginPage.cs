using AirportTicketBooking.Models;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Logging;

class LoginPage
{
    private static UserService _userService = new UserService();

    public async static void Login()
    {
        var user = await GetUser();

        if (user is Passenger)
        {
            Console.WriteLine($"Welcome passenger {user.Name}");
        }
        else if (user is Manager)
        {
            Console.WriteLine($"Welcome Manager {user.Name}");
        }
    }
    private static async Task<User> GetUser()
    {
        Console.WriteLine("Hello, welcome to your place");

    Again:
        Console.WriteLine("Please input your user id");
        var id = Console.ReadLine();
        while (string.IsNullOrEmpty(id) && int.TryParse(id, out int idNumber))
        {
            Console.WriteLine("input a valid user id");
            id = Console.ReadLine();
        }

        Console.WriteLine("Please input your password");
        var password = Console.ReadLine();
        while (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("input a valid user id");
            id = Console.ReadLine();
        }

        var user = await _userService.GetUserByIdAsync(id);
        if (user is null || user.Password != password)
        {
            Console.WriteLine("User Id or Password is wrong, try to input them again");
            Console.WriteLine("=====================================================");
            goto Again;
        }

        return user;
    }
}
