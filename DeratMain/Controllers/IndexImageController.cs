using DeratMain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexImageController : ControllerBase
    {
        private readonly IIndexImageService _indexImageService;

        public IndexImageController(IIndexImageService indexImageService)
        {
            _indexImageService = indexImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await _indexImageService.GetAllIndexImages());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string url)
        {
            await _indexImageService.AddIndexImage(url);
            return NoContent();
        }
    }
}
