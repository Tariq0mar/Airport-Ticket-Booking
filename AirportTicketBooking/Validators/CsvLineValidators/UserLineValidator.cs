using AirportTicketBooking.Interfaces.Validators;

namespace AirportTicketBooking.Validators.CsvLineValidators;

public class UserLineValidator : IValidateLine
{
    public bool LineValidator(string line)
    {
        var parts = line.Split(',');
        if (parts.Length != 6 && parts.Length != 7)
        {
            return false;
        }

        return true;
    }
}
