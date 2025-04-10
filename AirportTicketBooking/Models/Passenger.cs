
namespace AirportTicketBooking.Models;

public class Passenger : User
{
    public required string PassportNumber { get; init; }

    public override string ToString()
    {
        return $"{base.ToString()},{PassportNumber}";
    }
}
