﻿using OogstBeoordelingsAPI.Dtos;
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


        public void CreateUser(User newUser) => _userRepository.CreateUser(newUser);

        public Boolean UserExist(string userName, string password)
        {
            if (password != string.Empty && userName != string.Empty)
            {
                return _userRepository.GetUser(userName, password) != null;
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

            return _userRepository.GetUser(userId, username);
        }
    }
}

