using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Models.License;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly MainDbContext _dbContext;

        public FeedbackRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddFeedbackAsync(Feedback feedback)
        {
            await _dbContext.Feedbacks.AddAsync(feedback);
            await SaveChanges();
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            var itemToDelete = await _dbContext.Licenses
                .FirstOrDefaultAsync(l => l.Id == id);

            itemToDelete.IsDeleted = true;
            await SaveChanges();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _dbContext.Feedbacks
                .Where(l => !l.IsDeleted).ToListAsync();
        }

        public async Task<Feedback> GetFeedbackAsync(int id)
        {
            return await _dbContext.Feedbacks
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
