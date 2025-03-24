using AirportTicketBooking.Enums;
using System;

namespace AirportTicketBooking.Models;

public class Passenger : User
{
    public required string PassportNumber { get; init; }

    public Passenger(int userID, string name, string email, string password, string phoneNumber, string passportNumber) : base(userID, name, email, password, phoneNumber)
    {
        role = UserRole.Passenger;
        PassportNumber = passportNumber;
    }
}
