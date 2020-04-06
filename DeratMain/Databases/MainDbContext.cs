using DeratMain.Databases.Configuration;
using DeratMain.Databases.Entities;
using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeratMain.Databases
{
    public class MainDbContext : DbContext
    {

        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<IndexImage> IndexImages { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Callback> Callbacks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Organization> Organizations{ get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Perimeter> Perimeters { get; set; }
        public virtual DbSet<Trap> Traps { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
           
        }

        public  MainDbContext()
        {
            Database.EnsureCreated();   
            if(!Users.Any(e => e.Role=="admin" && e.Email =="admin" && e.Password =="admin"))
            {
                Users.Add(new User() { Role = "admin", Email = "admin", Password = "admin" });
            }
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IndexImageConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new LicenseConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new CallbackConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new TrapConfiguration());
            modelBuilder.ApplyConfiguration(new PerimeterConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());


            var entity = modelBuilder.Entity<EmployeeProject>();
            entity.HasKey(e => new { e.ProjectId, e.EmployeeId });

            modelBuilder.Entity<EmployeeProject>()
            .HasOne(sc => sc.Employee)
            .WithMany(s => s.ProjectsLnk)
            .HasForeignKey(sc => sc.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
           .HasOne(sc => sc.Project)
           .WithMany(c => c.EmployeesLnk)
           .HasForeignKey(sc => sc.ProjectId);
        }
    }
}
