
namespace AirportTicketBooking.Models;

public class Manager : User
{
    public Manager(string name, string email, string password, string phoneNumber) : base(name, email, password, phoneNumber)
    {
    }
    public Manager(string userId, string name, string email, string password, string phoneNumber) : base(userId, name, email, password, phoneNumber)
    {
    }

    public override string ToString()
    {
        return $"{base.ToString}";
    }
}
