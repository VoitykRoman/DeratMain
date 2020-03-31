using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerimetersController : ControllerBase
    {

        private readonly IPerimeterService _PerimeterService;

        public PerimetersController(IPerimeterService PerimeterService)
        {
            _PerimeterService = PerimeterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _PerimeterService.GetAllPerimetersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(PerimeterCreateModel ProjectCreateModel)
        {
            await _PerimeterService.AddPerimeterAsync(ProjectCreateModel, "admin");
            return NoContent();
        }
    }
}
