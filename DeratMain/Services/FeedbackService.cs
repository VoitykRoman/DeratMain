using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.Feedback;
using DeratMain.Models.License;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task AddFeedbackAsync(FeedbackCreateModel feedbackCreateModel)
        {
            var itemToUpdate = await _feedbackRepository.GetFeedbackAsync(feedbackCreateModel.UserId);
            if (itemToUpdate == null)
            {
                var feedback = new Feedback(feedbackCreateModel);
                await _feedbackRepository.AddFeedbackAsync(feedback);
            }
            else
            {
                itemToUpdate.Description = string.IsNullOrEmpty(feedbackCreateModel.Description)
               ? itemToUpdate.Description
               : feedbackCreateModel.Description;


                itemToUpdate.Rating = feedbackCreateModel.Rating < 1
                   ? itemToUpdate.Rating
                   : feedbackCreateModel.Rating;

                await _feedbackRepository.UpdateFeedbackAsync(itemToUpdate);
            }
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            await _feedbackRepository.DeleteFeedbackAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _feedbackRepository.GetAllFeedbacksAsync();
        }

        public async Task<Feedback> GetFeedbackAsync(int id)
        {
            return await _feedbackRepository.GetFeedbackAsync(id);
        }

        public async Task UpdateFeedbackAsync(FeedbackUpdateModel feedbackUpdateModel)
        {
            var itemToUpdate = await _feedbackRepository
                .GetFeedbackAsync(feedbackUpdateModel.Id);

            itemToUpdate.Description = string.IsNullOrEmpty(feedbackUpdateModel.Description)
                ? itemToUpdate.Description
                : feedbackUpdateModel.Description;


            itemToUpdate.Rating = feedbackUpdateModel.Rating < 1
               ? itemToUpdate.Rating
               : feedbackUpdateModel.Rating;

            await _feedbackRepository.UpdateFeedbackAsync(itemToUpdate);
        }
    }
}
