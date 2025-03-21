using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBooking;

public class User
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }

    public User(string name, int age, string email, string phoneNumber)
    {
        Name = name;
        Age = age;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
