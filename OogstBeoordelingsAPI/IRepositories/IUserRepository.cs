using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IRepositories
{
    public interface IUserRepository
    {
        public User GetUser(int userId, string userName);
        public User GetUser(string userName, string password);
        public void CreateUser(User user);
        public List<User> GetAll();
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
