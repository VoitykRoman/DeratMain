﻿using DeratMain.Interfaces.Services;
using DeratMain.Models.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {

        private readonly IFacilityService _FacilityService;

        public FacilitiesController(IFacilityService FacilityService)
        {
            _FacilityService = FacilityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _FacilityService.GetAllFacilitiesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(FacilityCreateModel ProjectCreateModel)
        {
            await _FacilityService.AddFacilityAsync(ProjectCreateModel, "admin");
            return NoContent();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetFacilityById(int id, int userId)
        {
            return Ok(await _FacilityService.GetFacilityById(id, userId));
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            await _FacilityService.DeleteFacility(id);
            return Ok();
        }
    }
}
