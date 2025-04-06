
namespace AirportTicketBooking.Models;

public class Manager : User
{
    public Manager(string name, string email, string password, string phoneNumber) : base(name, email, password, phoneNumber)
    {
    }
    public string ToString()
    {
        return $"{base.ToString()}";
    }
}
