using System;
using AirportTicketBooking;

namespace AirportTicketBooking;

public class Passenger : User
{
    public required string PassportNumber { get; init; }

    public Passenger(string name, int age, string email, string phoneNumber, string passportNumber) : base(name, age, email, phoneNumber)
    {
        PassportNumber = passportNumber;
    }

    public override string ToString()
    {
        return $"{Name},{PassportNumber}";
    }
}
