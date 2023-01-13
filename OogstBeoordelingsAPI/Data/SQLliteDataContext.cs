using Microsoft.EntityFrameworkCore;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Data
{
    public class SQLliteDataContext : DbContext
    {
        public SQLliteDataContext(DbContextOptions<SQLliteDataContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

    }
}
