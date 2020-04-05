using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;

namespace DeratMain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _ProjectRepository;

        public ProjectService(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }

        public async Task AddEmployeeToProject(IEnumerable<int> employeeIds, int projectId)
        {
            await _ProjectRepository.AddEmployeeToProject(employeeIds, projectId);
        }

        public async Task AddProjectAsync(ProjectCreateModel  projectCreateModel, string name)
        {
            var Project = new Project(projectCreateModel, name);
            await _ProjectRepository.AddProjectAsync(Project, projectCreateModel);
        }

        public async  Task ChangeProjectStatus(int id, string status)
        {
            await _ProjectRepository.ChangeProjectStatus(id, status);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(int id)
        {
            return await _ProjectRepository.GetAllProjectsAsync(id);
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _ProjectRepository.GetProjectById(id);
        }

        public async Task RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            await _ProjectRepository.RemoveEmployeeFromProject(employeeId, projectId);
        }

        public async Task DeleteProject(int id)
        {
            await _ProjectRepository.DeleteProject(id);
        }
    }
}
