using OogstBeoordelingsAPI.Dtos;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Repositories;
using System.Security.Claims;

namespace OogstBeoordelingsAPI.Services
{
    public class UserManagementService : IUserManagementService
    {

        UserRepositoryMock UserRepositoryMock;

        public UserManagementService() 
        {
            UserRepositoryMock = new UserRepositoryMock();
        }

        public Boolean Login(string username, string password)
        {
            return this.Authenticate(username, password);
        }

        private Boolean Authenticate(string username, string password)
        {
            var User = UserRepositoryMock.Users.FirstOrDefault(u =>
            u.Username == username &&
            u.Password == password);

            if (User != null)
            {
                return true;
            }

            return false;
        }

        public User GetUser(int userId, string userName)
        {
            if (userId != 0 && userName != String.Empty)
            {
                return UserRepositoryMock.Users.FirstOrDefault(u => u.Id == userId && u.Username == userName); ;
            }

            return null;
        }

        public User GetUser(string userName, string password)
        {
            if (password != string.Empty && userName != string.Empty)
            {
                return UserRepositoryMock.Users.FirstOrDefault(u => u.Username == userName && u.Password == password); ;
            }

            return null;
        }

        public void CreateUser(CreateUserDto createUserDto)
        {
            User newUser = new User(){ 
                Id = createUserDto.Id, 
                Username = createUserDto.Username, 
                Password = createUserDto.Password, 
                EmailAddress = createUserDto.EmailAddress, 
                UserRole = createUserDto.UserRole, 
                FirstName = createUserDto.FirstName, 
                LastName = createUserDto.LastName, 
                Zipcode = createUserDto.Zipcode, 
                City = createUserDto.City, 
                Adres = createUserDto.Adres};

            UserRepositoryMock.Users.Add(newUser);
        }

        public Boolean UserExist(string userName, string password)
        {
            if (password != string.Empty && userName != string.Empty)
            {
                return UserRepositoryMock.Users.FirstOrDefault(u => u.Username == userName && u.Password == password) != null;
            }

            return false;
        }

        public List<User> GetUsers()
        {
            return UserRepositoryMock.Users;
        }
    }
}

