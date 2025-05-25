using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Tests.Services.UserService
{
    public class GetAllUsersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new List<User>() };

            yield return new object[] {
                new List<User> {
                    new Passenger {
                        UserId = "p1", Role = UserRole.Passenger, Name = "Tariq", Email = "tariq@gmail.com",
                        Password = "123456", PhoneNumber = "123456", PassportNumber = "123456"
                    },
                    new Manager {
                        UserId = "m1", Role = UserRole.Manager, Name = "Tariq", Email = "tariq@gmail.com",
                        Password = "123456", PhoneNumber = "123456"
                    }
                }
            };
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
