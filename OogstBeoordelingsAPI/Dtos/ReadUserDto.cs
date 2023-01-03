using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Dtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Adres { get; set; }

        public ReadUserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            EmailAddress = user.EmailAddress;
            UserRole = user.UserRole.ToString();
            FirstName = user.FirstName;
            LastName = user.LastName;
            Zipcode = user.Zipcode;
            City = user.City;
            Adres = user.Adres;
        }
    }
}
