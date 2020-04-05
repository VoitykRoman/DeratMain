using DeratMain.Interfaces.Services;
using DeratMain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    //[Authorize(Roles = "admin")]
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

        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string email, string password)
        {
            return Ok(await _UserService.GetUserAsync(email, password));
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _UserService.GetAllEmployeesAsync());
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _UserService.GetAllClientsAsync());
        }

        [Route("[controller]/[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateModel userUpdateModel)
        {
            await _UserService.UpdateUser(userUpdateModel);
            return Ok();
        }

        [Route("[controller]/[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _UserService.DeleteUser(id);
            return Ok();
        }

    }
}
