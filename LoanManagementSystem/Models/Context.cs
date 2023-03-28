using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions options) : base (options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<ScoreCard> ScoreCards { get; set; }

        public DbSet<States> States  { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<LeadPrice> LeadPrices { get; set; }
    }
}
