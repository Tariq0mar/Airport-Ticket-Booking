using System;
using AirportTicketBooking;

namespace AirportTicketBooking;

class Passenger
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string PassportNumber { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }

    public Passenger(string name, int age, string passportNumber, string email, string phoneNumber)
    {
        Name = name;
        Age = age;
        PassportNumber = passportNumber;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
