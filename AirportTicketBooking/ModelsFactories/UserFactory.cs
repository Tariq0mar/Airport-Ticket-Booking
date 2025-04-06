using AirportTicketBooking.Models;

namespace AirportTicketBooking.ModelsFactories;

class UserFactory
{
    public static Manager CreateManager(string name, string email, string password, string phoneNumber)
    {
        return new Manager(name, email, password, phoneNumber);
    }

    public static Manager CreateManager(string userId, string name, string email, string password, string phoneNumber)
    {
        var manager = new Manager(name, email, password, phoneNumber);
        manager.UserId = userId;
        return manager;
    }
    public static Passenger CreatePassenger(string name, string email, string password, string phoneNumber, string passportNumber)
    {
        return new Passenger(name, email, password, phoneNumber, passportNumber);
    }

    public static Passenger CreatePassenger(string userId, string name, string email, string password, string phoneNumber, string passportNumber)
    {
        var passenger = new Passenger(name, email, password, phoneNumber, passportNumber);
        passenger.UserId = userId;
        return passenger;
    }
}
