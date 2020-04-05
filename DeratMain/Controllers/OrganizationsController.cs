using DeratMain.Interfaces.Services;
using DeratMain.Models.Organization;
using DeratMain.Models.Project;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetProjects(int id)
        {
            return Ok(await _organizationService.GetAllOrganizationsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrganizationCreateModel ProjectCreateModel)
        {
            await _organizationService.AddOrganizationAsync(ProjectCreateModel, "admin");
            return NoContent();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetOrganizationById(int id)
        {
            return Ok(await _organizationService.GetOrganizationById(id));
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            await _organizationService.DeleteFacility(id);
            return Ok();
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> RemoveClient(int clientId, int organizationId)
        {
            await _organizationService.RemoveClient(clientId, organizationId);
            return Ok();
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            await _organizationService.DeleteOrganization(id);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddClient(AddClientModel addClientModel)
        {
            await _organizationService.AddClient(addClientModel.ClientsIds, addClientModel.OrganizationId);
            return Ok();
        }

    }
}
