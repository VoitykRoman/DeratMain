using DeratMain.Interfaces.Services;
using DeratMain.Models.Feedback;
using DeratMain.Models.License;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await _feedbackService.GetAllFeedbacksAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(FeedbackCreateModel feedbackCreateModel)
        {
            await _feedbackService.AddFeedbackAsync(feedbackCreateModel);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(FeedbackUpdateModel feedbackUpdateModel)
        {
            await _feedbackService.UpdateFeedbackAsync(feedbackUpdateModel);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _feedbackService.DeleteFeedbackAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackByUserId(int id)
        {
            return Ok(await _feedbackService.GetFeedbackAsync(id));
        }
    }
}
