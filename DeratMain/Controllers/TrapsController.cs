using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrapsController : ControllerBase
    {

        private readonly ITrapService _TrapService;

        public TrapsController(ITrapService TrapService)
        {
            _TrapService = TrapService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _TrapService.GetAllTrapsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrapCreateModel ProjectCreateModel)
        {
            await _TrapService.AddTrapAsync(ProjectCreateModel, "admin");
            return NoContent();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetTrapById(int id)
        {
            return Ok(await _TrapService.GetTrapById(id));
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrap(int id)
        {
            await _TrapService.DeleteTrap(id);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> MarkAsReviewed(int id)
        {
            await _TrapService.MarkAsReviewed(id);
            return Ok();
        }
    }
}
