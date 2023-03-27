using Microsoft.EntityFrameworkCore;
using WordleDashboard.EFModels;

namespace WordleDashboard.EFContexts
{
    public class WordleDashboardContext : DbContext
    {


        public DbSet<DropdownValue>DropdownValues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=WordleDashboard;Trusted_Connection=True;encrypt=false");
        }

    }
}
