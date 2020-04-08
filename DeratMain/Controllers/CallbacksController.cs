using DeratMain.Interfaces.Services;
using DeratMain.Models.Callback;
using DeratMain.Models.License;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class CallbacksController : ControllerBase
    {
        private readonly ICallbackService _CallbackService;

        public CallbacksController(ICallbackService CallbackService)
        {
            _CallbackService = CallbackService;
        }
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await _CallbackService.GetAllCallbacksAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CallbackCreateModel CallbackCreateModel)
        {
            await _CallbackService.AddCallbackAsync(CallbackCreateModel);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(CallbackUpdateModel CallbackUpdateModel)
        {
            await _CallbackService.UpdateCallbackAsync(CallbackUpdateModel);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _CallbackService.DeleteCallbackAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _CallbackService.GetCallbackAsync(id));
        }
    }
}
