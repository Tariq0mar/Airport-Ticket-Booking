using System;
using AirportTicketBooking;

namespace AirportTicketBooking;

class Manager : User
{
    public required string PassportNumber { get; init; }

    public Manager(string name, int age, string email, string phoneNumber, string passportNumber) : base(name, age, email, phoneNumber)
    {
        PassportNumber = passportNumber;
    }
}
