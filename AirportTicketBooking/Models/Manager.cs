using AirportTicketBooking.Enums;
using System;

namespace AirportTicketBooking.Models;

class Manager : User
{
    public Manager(int userID, string name, string email, string password, string phoneNumber) : base(userID, name, email, password, phoneNumber)
    {
        role = UserRole.Manager;
    }
}
