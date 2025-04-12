namespace AirportTicketBooking.Presentations.Actions.UserActions
{
    class BookingPassengerActions
    {
        public void MyAccountData()
        {
            Console.WriteLine("=== My Account Data ===");
            Console.WriteLine($"Name: {_passenger.Name}");
            Console.WriteLine($"Email: {_passenger.Email}");
            Console.WriteLine($"Phone: {_passenger.PhoneNumber}");
            Console.WriteLine($"Passport Number: {_passenger.PassportNumber}");
        }
    }
}
