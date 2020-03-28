using DeratMain.Databases.Entities;
using DeratMain.Models.Feedback;
using DeratMain.Models.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();

        Task<Feedback> GetFeedbackAsync(int id);

        Task AddFeedbackAsync(FeedbackCreateModel feedbackCreateModel);

        Task UpdateFeedbackAsync(FeedbackUpdateModel feedbackUpdateModel);

        Task DeleteFeedbackAsync(int id);
    }
}
