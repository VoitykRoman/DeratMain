using DeratMain.Interfaces.Services;
using DeratMain.Models;
using DeratMain.Models.TeamMember;
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TeamMemberUpdateModel model)
        {
            await _teamMemberService.UpdateTeamMemberAsync(model);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _teamMemberService.DeleteTeamMemberAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _teamMemberService.GetTeamMemberAsync(id));
        }

    }
}
