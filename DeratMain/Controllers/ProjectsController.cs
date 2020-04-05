using DeratMain.Databases.Repositories;
using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _ProjectService;
       

        public ProjectsController(IProjectService ProjectService)
        {
            _ProjectService = ProjectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProjects(int id)
        {
            return Ok(await _ProjectService.GetAllProjectsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProjectCreateModel ProjectCreateModel)
        {
            await _ProjectService.AddProjectAsync(ProjectCreateModel, "admin");
            return NoContent();
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> ChangeProjectStatus(int id, string status)
        {
            await _ProjectService.ChangeProjectStatus(id, status);
            return NoContent();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetProjectById(int id)
        {
            return Ok(await _ProjectService.GetProjectById(id));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddEmployeeToProject(AddEmployeesToProject addEmployeesToProject)
        {
            await _ProjectService.AddEmployeeToProject(addEmployeesToProject.EmployeesIds, addEmployeesToProject.ProjectId);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            await _ProjectService.RemoveEmployeeFromProject(employeeId, projectId);
            return Ok();
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _ProjectService.DeleteProject(id);
            return Ok();
        }
    }
}
