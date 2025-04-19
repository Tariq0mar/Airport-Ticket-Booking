using AirportTicketBooking.Enums;
using AirportTicketBooking.InputModels.InputUser;
using AirportTicketBooking.Interfaces.Services;
using AirportTicketBooking.Models;
using AirportTicketBooking.Services;

namespace AirportTicketBooking.Presentations.Actions.UserActions;

public static class UserManagerActions
{
    private static readonly IUserService _userService = new UserService();

    public static async Task AddUser()
    {
        var user = InputUser.Input();

        var result = await _userService.AddAsync(user);
        Console.WriteLine($"User added with ID: {result}");
    }

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

    public static async Task GetUserByEmail()
    {
        Console.WriteLine("Enter User Email:");
        var email = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Invalid input, try again");
            email = Console.ReadLine();
        }

        var user = await _userService.GetByEmailAsync(email);

        Console.WriteLine(user != null
            ? user.ToString()
            : "User not found.");
    }

    public static async Task GetAllUsers()
    {
        Console.WriteLine("=====List of Users=====");
        var users = await _userService.GetAllAsync();
        foreach (var user in users)
        {
            Console.WriteLine(user.ToString());
            Console.WriteLine("-------------------");
        }
    }

    public static async Task UpdateUser()
    {
        Console.WriteLine("Enter User ID:");
        var userId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(userId) || int.TryParse(userId, out _))
        {
            Console.WriteLine("Invalid input, try again");
            userId = Console.ReadLine();
        }

        var existingUser = await _userService.GetByIdAsync(userId);

        if (existingUser is not null)
        {
            if (existingUser.Role == UserRole.Passenger)
            {
                var passenger = InputUser.InputPassenger();
                var updatedUser = new Passenger
                {
                    UserId = passenger.UserId,
                    Role = UserRole.Passenger,
                    Email = passenger.Email,
                    Name = passenger.Name,
                    Password = passenger.Password,
                    PhoneNumber = passenger.PhoneNumber,
                    PassportNumber = passenger.PassportNumber
                };

                var success = await _userService.UpdateAsync(updatedUser);
                Console.WriteLine(success ? "User updated successfully." : "Failed to update user.");
            }
            else
            {
                var manager = InputUser.InputManager();
                var updatedUser = new Manager
                {
                    UserId = manager.UserId,
                    Role = UserRole.Passenger,
                    Email = manager.Email,
                    Name = manager.Name,
                    Password = manager.Password,
                    PhoneNumber = manager.PhoneNumber,
                };

                var success = await _userService.UpdateAsync(updatedUser);
                Console.WriteLine(success ? "User updated successfully." : "Failed to update user.");
            }
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
    
    public static async Task DeleteUser()
    {
        Console.WriteLine("Enter User ID:");
        var userId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(userId) || int.TryParse(userId, out _))
        {
            Console.WriteLine("Invalid input, try again");
            userId = Console.ReadLine();
        }

        var success = await _userService.DeleteAsync(userId);
        Console.WriteLine(success ? "User updated successfully." : "Failed to update user.");
    }
}
