using AirportTicketBooking.Interfaces.Validators;

namespace AirportTicketBooking.Validators.CsvLineValidators;

public class BookingLineValidator : IValidateLine
{
    public bool LineValidator(string line)
    {
        var parts = line.Split(',');

        if (parts.Length != 3)
        {
            return false;
        }

        return true;
    }
}
