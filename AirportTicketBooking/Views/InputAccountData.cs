using AirportTicketBooking.Models;
using AirportTicketBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.Views;

class InputAccountData
{
    private static readonly UserService _userService = new UserService();

    public static async Task<User> InputUserAccountData()
    {
        Console.WriteLine("Hello, welcome to your place");

        while (true)
        {
            Console.WriteLine("Please input your user id");
            var id = Console.ReadLine();
            while (string.IsNullOrEmpty(id) && int.TryParse(id, out var idNumber))
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

            var user = await _userService.UserAuthentication(id, password);
            if (user is null)
            {
                Console.WriteLine("User Id or Password is wrong, try to input them again");
                Console.WriteLine("=====================================================");
            }
            else
            {
                return user;
            }
        }
    }
}
