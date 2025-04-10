using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models;

public class User
{
    public required string UserId { get; init; } = string.Empty;
    public required UserRole Role { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PhoneNumber { get; init; }

    public override string ToString()
    {
        return $"{UserId},{Name},{Email},{Password},{PhoneNumber}";
    }
}
