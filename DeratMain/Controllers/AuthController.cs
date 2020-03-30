using DeratMain.Authentication;
using DeratMain.Databases;
using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Services;
using DeratMain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Post([FromBody]LoginModel loginModel)
        {
            try
            {
                return Ok(await _identityService.Login(loginModel));
            }
            catch
            {
                return NotFound("Incorrect email or password");
            }
            }


    }
}
