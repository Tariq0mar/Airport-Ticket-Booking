using AirportTicketBooking.Serializers;
using AirportTicketBooking.Interfaces.Repositories;
using AirportTicketBooking.Models;
using AirportTicketBooking.Serializers;

namespace AirportTicketBooking.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _filePath = @"../../../DataBase/users.csv";
    private static int _idCounter = 0;

    public async Task<string> AddAsync(User user)
    {
        try
        {
            var line = $"{ConvertToCsv.FromUser(user)}{Environment.NewLine}";
            var parts = line.Split(',');
            parts[0] = (++_idCounter).ToString("D11");
            line = string.Join(",", parts);

            await File.AppendAllTextAsync(_filePath, line + Environment.NewLine);
            Console.WriteLine(line);
            return parts[0];
        }
        catch
        {
            return (0).ToString("D11");
        }
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        var users = await GetAllAsync();
        return users.FirstOrDefault(u => u.UserId == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var users = await GetAllAsync();
        return users.FirstOrDefault(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var usersList = new List<User>();

        foreach (var line in lines)
        {
            var user = ConvertFromCsv.ToUser(line);

            if (user is not null)
            {
                usersList.Add(user);
            }
        }

        return usersList;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        try
        {
            var users = await GetAllAsync();
            var updatedUsers = users.Select(u => u.UserId == user.UserId ? user : u).ToList();
            await SaveAllAsync(updatedUsers);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var users = await GetAllAsync();
            var filteredUsers = users.Where(u => u.UserId != id);
            await SaveAllAsync(filteredUsers);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private async Task SaveAllAsync(IEnumerable<User> users)
    {
        var lines = new List<string>(users.Select(u => $"{ConvertToCsv.FromUser(u)}{Environment.NewLine}"));
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}
