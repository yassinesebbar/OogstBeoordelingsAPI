using Newtonsoft.Json.Converters;
using OogstBeoordelingsAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OogstBeoordelingsAPI.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public UserRole UserRole { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Adres { get; set; }

        public User MapToUser()
        {
            return new User()
            {
                Username = Username,
                Password = Password,
                EmailAddress = EmailAddress,
                UserRole = UserRole,
                FirstName = FirstName,
                LastName = LastName,
                Zipcode = Zipcode,
                City = City,
                Adres = Adres
            };
        }

    }
}
