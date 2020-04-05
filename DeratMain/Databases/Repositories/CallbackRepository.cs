using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Models.License;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class CallbackRepository : ICallbackRepository
    {
        private readonly MainDbContext _dbContext;

        public CallbackRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddCallbackAsync(Callback Callback)
        {
            await _dbContext.Callbacks.AddAsync(Callback);
            await SaveChanges();
        }

        public async Task DeleteCallbackAsync(int id)
        {
            var itemToDelete = await _dbContext.Callbacks
                .FirstOrDefaultAsync(l => l.Id == id);

            itemToDelete.IsDeleted = true;
            await SaveChanges();
        }

        public async Task<IEnumerable<Callback>> GetAllCallbacksAsync()
        {
            return await _dbContext.Callbacks
                .AsNoTracking()
                .Where(l => !l.IsDeleted).ToListAsync();
        }

        public async Task<Callback> GetCallbackAsync(int id)
        {
            return await _dbContext.Callbacks
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateCallbackAsync(Callback callback)
        {
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
