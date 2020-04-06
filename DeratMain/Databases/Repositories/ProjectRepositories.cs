using DeratMain.Databases.Entities;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Interfaces.Databases;
using DeratMain.Models.Project;
using Microsoft.EntityFrameworkCore;
using System;
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
            project.Organization = await _dbContext.Organizations.FirstOrDefaultAsync(e => e.Id == ProjectCreateModel.OrganizationId);
            foreach (var emp in ProjectCreateModel.Employees)
            {
                var employee = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Id == emp);
                project.Events.Add(new Event($"The employee {employee.FirstName} {employee.LastName} has been added to project at {DateTime.Now}", project));
            }
            
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
            project.Events.Add(new Event($"The status of the project has been changed to {status} at {DateTime.Now}", project));
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
            var employee = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Id == employeeId);
            project.Events.Add(new Event($" The employee {employee.FirstName} {employee.LastName} has been removed from project at {DateTime.Now}", project));
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
            foreach (var emp in employeeIds)
            {
                var employee = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Id == emp);
                project.Events.Add(new Event($"The employee {employee.FirstName} {employee.LastName} has been added to project at {DateTime.Now}", project));
            }
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
