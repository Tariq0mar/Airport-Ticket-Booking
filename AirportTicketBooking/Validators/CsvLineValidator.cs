
using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;
using System.Globalization;
using System.IO;

namespace AirportTicketBooking.Validators;

class CsvLineValidator
{
    public static bool FlightLineValidator(string line)
    {
        var parts = line.Split(',');

        if (parts.Length < 8)
        {
            return false;
        }

        if (!Enum.TryParse(parts[1], out Country _) || 
            !DateTime.TryParse(parts[2], null, DateTimeStyles.RoundtripKind, out _) ||
            !Enum.TryParse(parts[3], out Airport _))  
        {
            return false;  
        }
        
        if (!Enum.TryParse(parts[4], out Country _) ||  
            !DateTime.TryParse(parts[5], null, DateTimeStyles.RoundtripKind, out _) ||
            !Enum.TryParse(parts[6], out Airport _)) 
        {
            return false; 
        }

        
        if (!int.TryParse(parts[7], out var size) || size < 0)
        {
            return false; 
        }

        for (var i = 1; i <= size; i++)
        {
            if (!Enum.TryParse(parts[4], out FlightClass _) ||  
                !int.TryParse(parts[i + 8], out _))  
            {
                return false;  
            }
        }

        return true;  
    }

    public static bool BookingLineValidator(string line)
    {
        var parts = line.Split(',');

        if (parts.Length != 3)
        {
            return false;
        }

        return true;
    }

    public static bool UserLineValidator(string line)
    {
        var parts = line.Split(',');
        if(parts.Length != 5 && parts.Length != 6)
        {
            return false;
        }

        return true;
    }
}
