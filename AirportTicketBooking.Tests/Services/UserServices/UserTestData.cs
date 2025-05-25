using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Tests.Services.UserService
{
    public class UserTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Passenger {
                    UserId = "p1", Role = UserRole.Passenger, Name = "Tariq", Email = "tariq@mail.com",
                    Password = "pass123", PhoneNumber = "123456", PassportNumber = "X123456"
                }
            };
            yield return new object[] {
                new Manager {
                    UserId = "m1", Role = UserRole.Manager, Name = "Omar", Email = "omar@mail.com",
                    Password = "adminpass", PhoneNumber = "654321"
                }
            };
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
