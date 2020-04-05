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
            _dbContext.Projects.Add(project);
            await SaveChanges();

            foreach (var e in ProjectCreateModel.Employees)
            {
                project.EmployeesLnk.Add(new EmployeeProject { EmployeeId = e, ProjectId = project.Id });
            }
            await SaveChanges();


        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(int id)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .Include(e => e.ProjectsLnk)
                .ThenInclude(e => e.Project).ThenInclude(e => e.Organization)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (user.Role == "admin")
            {
                return await _dbContext.Projects
                    .AsNoTracking()
               .Where(l => !l.IsDeleted)
                   .Include(e => e.Organization)
                   .Include(a => a.EmployeesLnk)
                   .ThenInclude(t => t.Employee)
                   .Include(q => q.Events)
                   .AsNoTracking()
                   .ToListAsync();
            }
            else
            {
                var projects = user.ProjectsLnk.Select(e => e.Project).ToList();
                return projects;
            }




        }

        public async Task ChangeProjectStatus(int id, string status)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(e => e.Id == id);

            project.Status = status;

            await SaveChanges();
        }


        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _dbContext.Projects
                .AsNoTracking()
                .Include(r => r.EmployeesLnk)
                .ThenInclude(ee => ee.Employee)
                .Include(q => q.Events)
                .Include(w => w.Organization)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            var project = await _dbContext.Projects.Include(w => w.EmployeesLnk)
                .FirstOrDefaultAsync(e => e.Id == projectId);
            var lnk = project.EmployeesLnk
                .FirstOrDefault(e => e.EmployeeId == employeeId && e.ProjectId == projectId);
            project.EmployeesLnk.Remove(lnk);
            await SaveChanges();
        }

        public async Task AddEmployeeToProject(IEnumerable<int> employeeIds, int projectId)
        {
            var project = await _dbContext.Projects
               .Include(w => w.EmployeesLnk)
               .FirstOrDefaultAsync(e => e.Id == projectId);

            foreach (var employeeId in employeeIds)
            {
                project.EmployeesLnk.Add(new EmployeeProject { EmployeeId = employeeId, ProjectId = projectId });
            }
            await SaveChanges();
        }

        public async Task DeleteProject(int id)
        {
            var project = await _dbContext.Projects.Include(e => e.Events).FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Projects.Remove(project);

            await SaveChanges();
        }
    }
}
