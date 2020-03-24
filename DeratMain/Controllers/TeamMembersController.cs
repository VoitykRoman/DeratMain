using DeratMain.Interfaces.Services;
using DeratMain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMembersController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeamMembers()
        {
            return Ok(await _teamMemberService.GetAllTeamMembersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TeamMemberCreateModel model )
        {
            await _teamMemberService.AddTeamMemberAsync(model);
            return NoContent();
        }
    }
}
