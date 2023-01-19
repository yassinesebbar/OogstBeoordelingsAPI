using System.ComponentModel.DataAnnotations;

namespace OogstBeoordelingsAPI.Dtos
{
    public class LoginDto
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
