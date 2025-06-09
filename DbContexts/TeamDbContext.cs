using DSCC.CW1._14039.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._14039.DbContexts
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options) { }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
