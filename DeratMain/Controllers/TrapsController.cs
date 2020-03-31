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
    }
}
