using OogstBeoordelingsAPI.Dtos;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Repositories;
using System.Security.Claims;
using BCrypt.Net;

namespace OogstBeoordelingsAPI.Services
{
    public class UserManagementService : IUserManagementService
    {

        private readonly IUserRepository _userRepository;

        public UserManagementService(IUserRepository userRepo) 
        {
            _userRepository = userRepo;
        }

        public Boolean Login(string username, string password) => this.Authenticate(username, password);

        private Boolean Authenticate(string userName, string password)
        {
            User user = _userRepository.GetUser(userName);

            if(this.PasswordIsValid(user.Password, password))
            {
                return true;
            }

            return false;
        }

        public User GetUser(string userName, string password)
        {
            User user = _userRepository.GetUser(userName);

            if (this.PasswordIsValid(user.Password, password))
            {
                return user;
            }
            return null;
        }

        public void CreateUser(User newUser)
        {
            newUser.Password = this.HashPassword(newUser.Password);
           _userRepository.CreateUser(newUser);
        } 

        public Boolean UserExist(string userName, string password)
        {
            if (password != string.Empty && userName != string.Empty)
            {
                return _userRepository.GetUser(userName) != null;
            }

            return false;
        }

        public List<User> GetUsers() => _userRepository.GetAll();

        public void DeleteUser(User user) => _userRepository.DeleteUser(user);

        public User GetUser(ClaimsPrincipal user)
        {
            var Claims = (user.Identity as ClaimsIdentity).Claims;
            var userId = int.Parse(Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value);
            var username = Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return _userRepository.GetUser(username);
        }

        public bool UserExist(string userName)
        {
            if (userName != string.Empty)
            {
                return _userRepository.GetUser(userName) != null;
            }

            return false;
        }

        private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        private Boolean PasswordIsValid(string hashedPassword, string password) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        public void DeleteAllUsers(User CurrentUser)
        {
            List<User> users = _userRepository.GetAll();

            users.Remove(CurrentUser);

            foreach (User user in users)
            {
                _userRepository.DeleteUser(user);
            }
        }
    }
}

