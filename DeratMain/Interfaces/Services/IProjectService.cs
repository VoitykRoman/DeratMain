using DeratMain.Databases.Entities;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync(int id);

        Task AddProjectAsync(ProjectCreateModel project, string name);

        Task ChangeProjectStatus(int id, string status);

        Task<Project> GetProjectById(int id);

        Task RemoveEmployeeFromProject(int employeeId, int projectId);

        Task AddEmployeeToProject(IEnumerable<int> employeeIds, int projectId);

        Task DeleteProject(int id);
    }
}
