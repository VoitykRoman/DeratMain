using DeratMain.Databases.Entities;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Interfaces.Databases;
using DeratMain.Models.Project;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MainDbContext _dbContext;

        public ProjectRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProjectAsync(Project project, ProjectCreateModel ProjectCreateModel)
        {

            project.Organization = await _dbContext.Organizations.FirstOrDefaultAsync(e => e.Id == project.OrganizationId);
            
            await _dbContext.Projects.AddAsync(project);
            await SaveChanges();
            await AddEmployeesToProjectAsync(project, ProjectCreateModel.Employees);
        }

        private async Task AddEmployeesToProjectAsync(Project project, IEnumerable<int> employees)
        {
            foreach (var employee in employees)
            {
                _dbContext.EmployeeProjects.Add(new EmployeeProject { EmployeeId = employee, ProjectId = project.Id });
            }
            project.Employees = await _dbContext.Users.Where(e => employees.Contains(e.Id)).ToListAsync(); 
            await SaveChanges();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects
                .Where(l => !l.IsDeleted)
                    .Include(e=>e.Organization).Include(a => a.Employees).Include(q => q.Events).ToListAsync();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
