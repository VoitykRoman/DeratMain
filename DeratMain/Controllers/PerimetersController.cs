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

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetPerimeterById(int id)
        {
            return Ok(await _PerimeterService.GetPerimeterById(id));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> MarkAsReviewed(int id)
        {
            await _PerimeterService.MarkAsReviewed(id);
            return Ok();
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeletePerimeter(int id)
        {
            await _PerimeterService.DeletePerimeter(id);
            return Ok();
        }
    }
}
