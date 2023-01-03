using OogstBeoordelingsAPI.Dtos;
using OogstBeoordelingsAPI.Models;
using System.Security.Claims;

namespace OogstBeoordelingsAPI.IServices
{
 

    public interface IUserManagementService
    {
        Boolean Login(string username, string password);

        public User GetUser(int userId, string userName);
        public User GetUser(string userName, string password);
        public void CreateUser(CreateUserDto createUserDto);
        public Boolean UserExist(string userName, string password);
        public List<User> GetUsers();
    }
}
