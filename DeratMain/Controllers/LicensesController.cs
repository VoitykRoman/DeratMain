using DeratMain.Interfaces.Services;
using DeratMain.Models.License;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LicensesController : ControllerBase
    {
        private readonly ILicenseService _licenseService;

        public LicensesController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await _licenseService.GetAllLicensesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(LicenseCreateModel licenseCreateModel)
        {
            await _licenseService.AddLicenseAsync(licenseCreateModel);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(LicenseUpdateModel licenseUpdateModel)
        {
            await _licenseService.UpdateLicenseAsync(licenseUpdateModel);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _licenseService.DeleteLicenseAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _licenseService.GetLicenseAsync(id));
        }
    }
}
