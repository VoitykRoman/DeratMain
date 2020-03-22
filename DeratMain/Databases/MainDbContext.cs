using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeratMain.Databases
{
    public class MainDbContext : DbContext
    {

        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<IndexImage> IndexImages { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.EnsureCreated();

            TeamMember.Configure(modelBuilder);
            IndexImage.Configure(modelBuilder);
        }
    }
}
