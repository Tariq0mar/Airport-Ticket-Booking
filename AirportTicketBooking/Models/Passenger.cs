
namespace AirportTicketBooking.Models;

public class Passenger : User
{
    public string PassportNumber { get; init; }

    public Passenger(string name, string email, string password, string phoneNumber, string passportNumber) : base(name, email, password, phoneNumber)
    {
        PassportNumber = passportNumber;
    }
    public Passenger(string userId, string name, string email, string password, string phoneNumber, string passportNumber) : base(userId, name, email, password, phoneNumber)
    {
        PassportNumber = passportNumber;
    }

    public override string ToString()
    {
        return $"{base.ToString},{PassportNumber}";
    }
}
