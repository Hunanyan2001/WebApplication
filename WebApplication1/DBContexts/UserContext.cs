using Microsoft.EntityFrameworkCore;
using WebApplication1.Entity;

namespace WebApplication1.DBContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
