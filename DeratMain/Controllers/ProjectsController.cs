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
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _ProjectService.GetAllProjectsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProjectCreateModel ProjectCreateModel)
        {
            await _ProjectService.AddProjectAsync(ProjectCreateModel, "admin");
            return NoContent();
        }
    }
}
