using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Models
{
    public enum UserRole
    {
        Harvester = 1,
        Assessor = 2,
        Administrator = 3
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
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
    }
}
