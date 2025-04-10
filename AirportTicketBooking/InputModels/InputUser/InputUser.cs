using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking.InputModels.InputUser;

class InputUser
{
    public static User InputManager()
    {
        var manager = new Manager {
            UserId = string.Empty,
            Role = UserRole.Manager,
            Name = InputName(),
            Email = InputEmail(),
            Password = InputPassword(),
            PhoneNumber = InputPhoneNumber()
        };

        return manager;
    }
    public static User InputPassenger()
    {
        var passenger = new Passenger
        {
            UserId = string.Empty,
            Role = UserRole.Passenger,
            Name = InputName(),
            Email = InputEmail(),
            Password = InputPassword(),
            PhoneNumber = InputPhoneNumber(),
            PassportNumber = InputPassportNumber()
        };

        return passenger;
    }

    private static string InputName()
    {
        Console.WriteLine("Please enter your name : ");

        var name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            name = Console.ReadLine();
        }

        return name;
    }
    private static string InputEmail()
    {
        Console.WriteLine("Please enter your Email : ");

        var email = Console.ReadLine();
        while (string.IsNullOrEmpty(email))
        {
            email = Console.ReadLine();
        }

        return email;
    }
    private static string InputPassword()
    {
        Console.WriteLine("Please enter your password : ");

        var password = Console.ReadLine();
        while (string.IsNullOrEmpty(password))
        {
            password = Console.ReadLine();
        }

        return password;
    }
    private static string InputPhoneNumber()
    {
        Console.WriteLine("Please enter your phoneNumber : ");

        var phoneNumber = Console.ReadLine();
        while (string.IsNullOrEmpty(phoneNumber))
        {
            phoneNumber = Console.ReadLine();
        }

        return phoneNumber;
    }
    private static string InputPassportNumber()
    {
        Console.WriteLine("Please enter your passportNumber : ");

        var passportNumber = Console.ReadLine();
        while (string.IsNullOrEmpty(passportNumber))
        {
            passportNumber = Console.ReadLine();
        }

        return passportNumber;
    }
}