using OogstBeoordelingsAPI.Data;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;


        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user).Context.SaveChanges(); 
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user).Context.SaveChanges();
        } 

        public List<User> GetAll() => _context.Users.ToList();

        public User GetUser(int userId, string userName) => _context.Users.FirstOrDefault(u => u.Id == userId && u.Username == userName);

        public User GetUser(string userName, string password) => _context.Users.FirstOrDefault(u => u.Username == userName && u.Password == password);

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
