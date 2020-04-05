using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync(int id);

        Task AddProjectAsync(Project project, ProjectCreateModel ProjectCreateModel);

        Task ChangeProjectStatus(int id, string status);

        Task<Project> GetProjectById(int id);

        Task RemoveEmployeeFromProject(int employeeId, int projectId);

        Task AddEmployeeToProject(IEnumerable<int> employeeIds, int projectId);

        Task DeleteProject(int id);
    }
}
