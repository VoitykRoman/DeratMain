using DeratMain.Interfaces.Services;
using DeratMain.Models.IndexImage;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post(IndexImageCreateModel indexImage)
        {
            await _indexImageService.AddIndexImage(indexImage);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(IndexImageUpdateModel indexImage)
        {
            await _indexImageService.UpdateImageAsync(indexImage);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _indexImageService.DeleteIndexImageAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _indexImageService.GetIndexImageAsync(id));
        }
    }
}
