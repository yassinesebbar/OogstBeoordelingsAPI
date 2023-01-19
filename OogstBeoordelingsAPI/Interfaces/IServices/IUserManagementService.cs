using OogstBeoordelingsAPI.Models;
using System.Security.Claims;

namespace OogstBeoordelingsAPI.IServices
{
 

    public interface IUserManagementService
    {
        Boolean Login(string username, string password);
        public User GetUser(string userName, string password);
        public User GetUser(ClaimsPrincipal identity);
        public void CreateUser(User newUser);
        public Boolean UserExist(string userName, string password);
        public Boolean UserExist(string userName);
        public List<User> GetUsers();
        public void DeleteAllUsers(User CurrentUser);
    }
}
