using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IRepositories
{
    public interface IUserRepository
    {
        public User GetUser(string userName);
        public void CreateUser(User user);
        public List<User> GetAll();
        public void DeleteUser(User user);
    }
}
