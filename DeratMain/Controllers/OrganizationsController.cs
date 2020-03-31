using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {

        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _organizationService.GetAllOrganizationsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrganizationCreateModel ProjectCreateModel)
        {
            await _organizationService.AddOrganizationAsync(ProjectCreateModel, "admin");
            return NoContent();
        }
    }
}
