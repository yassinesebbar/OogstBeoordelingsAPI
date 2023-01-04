using OogstBeoordelingsAPI.Dtos;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Repositories;
using System.Security.Claims;

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
            User user = _userRepository.GetUser(userName, password);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public User GetUser(int userId, string userName)
        {
            User user = _userRepository.GetUser(userId, userName);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public User GetUser(string userName, string password)
        {
            User user = _userRepository.GetUser(userName, password);

            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void CreateUser(CreateUserDto createUserDto)
        {
            User newUser = new User(){ 
                Username = createUserDto.Username, 
                Password = createUserDto.Password, 
                EmailAddress = createUserDto.EmailAddress, 
                UserRole = createUserDto.UserRole, 
                FirstName = createUserDto.FirstName, 
                LastName = createUserDto.LastName, 
                Zipcode = createUserDto.Zipcode, 
                City = createUserDto.City, 
                Adres = createUserDto.Adres};

            _userRepository.CreateUser(newUser);
        }

        public Boolean UserExist(string userName, string password)
        {
            if (password != string.Empty && userName != string.Empty)
            {
                return _userRepository.GetUser(userName, password) != null;
            }

            return false;
        }

        public List<User> GetUsers() => _userRepository.GetAll();
        
    }
}

