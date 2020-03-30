using DeratMain.Interfaces.Services;
using DeratMain.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _UserService.GetAllUsersAsync());
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateModel UserCreateModel)
        {
            await _UserService.AddUserAsync(UserCreateModel);
            return NoContent();
        }

        [Route("[controller]/[action]/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserUpdateModel UserUpdateModel, int id)
        {
            await _UserService.UpdateUserAsync(UserUpdateModel, id);
            return NoContent();
        }

        [Route("[controller]/[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _UserService.DeleteUserAsync(id);
            return NoContent();
        }

        [Route("[controller]/[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _UserService.GetUserAsync(id));
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            return Ok(await _UserService.GetUsersByRole(role));
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string email, string password)
        {
            return Ok(await _UserService.GetUserAsync(email, password));
        }
    }
}
