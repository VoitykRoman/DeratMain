using Microsoft.AspNetCore.Mvc;

namespace DeratMain.Controllers
{
    [Route("controller")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(true);
        }
    }
}
