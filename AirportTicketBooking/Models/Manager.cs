using AirportTicketBooking.Enums;
using System;

namespace AirportTicketBooking.Models;

class Manager : User
{
    public Manager(int userID, string name, string email, string password, string phoneNumber, int age) : base(name, email, password, phoneNumber, age)
    {
        role = UserRole.Manager;
    }
}
