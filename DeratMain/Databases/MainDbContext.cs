using DeratMain.Databases.Configuration;
using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeratMain.Databases
{
    public class MainDbContext : DbContext
    {

        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<IndexImage> IndexImages { get; set; }

        public virtual DbSet<License> Licenses { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public MainDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IndexImageConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new LicenseConfiguration());
        }
    }
}
