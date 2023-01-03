using Microsoft.EntityFrameworkCore;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();

    }
}
