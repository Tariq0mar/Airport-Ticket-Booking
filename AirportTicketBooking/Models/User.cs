
namespace AirportTicketBooking.Models;

public class User
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    public User(string name, string email, string password, string phoneNumber)
    {
        Name = name;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    public User(string userId, string name, string email, string password, string phoneNumber) : this(name, email, password, phoneNumber)
    {
        UserId = userId;
    }

    public override string ToString()
    {
        return $"{UserId},{Name},{Email},{Password},{PhoneNumber}";
    }
}
