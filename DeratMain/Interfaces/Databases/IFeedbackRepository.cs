using DeratMain.Databases.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();

        Task<Feedback> GetFeedbackAsync(int id);

        Task AddFeedbackAsync(Feedback license);

        Task UpdateFeedbackAsync(Feedback license);

        Task DeleteFeedbackAsync(int id);
    }
}
