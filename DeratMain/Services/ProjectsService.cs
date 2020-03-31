using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using DeratMain.Models.License;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddProjectAsync(ProjectCreateModel  projectCreateModel, string name)
        {
            var Project = new Project(projectCreateModel, name);
            await _ProjectRepository.AddProjectAsync(Project, projectCreateModel);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _ProjectRepository.GetAllProjectsAsync();
        }

    }
}
