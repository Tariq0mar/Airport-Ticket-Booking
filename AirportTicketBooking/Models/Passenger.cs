using AirportTicketBooking.Enums;
using System;

namespace AirportTicketBooking.Models;

public class Passenger : User
{
    public required string PassportNumber { get; init; }

    public Passenger(int userID, string name, string email, string password, string phoneNumber, int age, string passportNumber) : base(name, email, password, phoneNumber, age)
    {
        role = UserRole.Passenger;
        PassportNumber = passportNumber;
    }
}
