using System;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models;

public class User
{
    public UserRole role;
    public required int UserID { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PhoneNumber { get; init; }
    public required int Age { get; init; }

    public User(int userID, string name, string email, string password, string phoneNumber, int age)
    {
        UserID = userID;
        Name = name;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        Age = age;
    }
}
