using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Repositories;

namespace OogstBeoordelingsAPI.Repositories
{
    public class UserRepositoryMock
    {
        public List<User> Users = new List<User>()
        {
            new User() { Id = 1 , Username = "teleraccount", Password = "telera", EmailAddress = "teler@hotmail.com", UserRole = UserRole.Teler, FirstName = "Jan", LastName = "", Zipcode = "1111AA", City = "Den Bosch", Adres = "Rondweg 12"},
            new User() { Id = 2, Username = "adminaccount", Password = "admina", EmailAddress = "admin@hotmail.com", UserRole = UserRole.Administrator, FirstName = "Peter", LastName = "", Zipcode = "2222BB", City = "Breda", Adres = "Bergstraat 1"},
            new User() { Id = 3, Username = "beoordeleraccount", Password = "beoordelera", EmailAddress = "beoordeler@hotmail.com", UserRole = UserRole.Beoordeler, FirstName = "Hans", LastName = "", Zipcode = "3333CC", City = "Utrecht", Adres = "Dorpsstraat 12"},
        };
    }
}
