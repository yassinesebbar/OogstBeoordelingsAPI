using OogstBeoordelingsAPI.Data;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLliteDataContext _context;

        public UserRepository(SQLliteDataContext context){ _context = context;}

        public void CreateUser(User user) => _context.Users.Add(user).Context.SaveChanges(); 

        public void DeleteUser(User user) => _context.Users.Remove(user).Context.SaveChanges();

        public List<User> GetAll() => _context.Users.ToList();

        public User GetUser(string userName) => _context.Users.FirstOrDefault(u => u.Username == userName);

    }
}
