using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly MainDbContext _dbContext;

        public ImageRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddImageAsync(IndexImage image)
        {
            await _dbContext.IndexImages.AddAsync(image);
            await SaveChanges();
        }

        public async Task<IEnumerable<IndexImage>> GetAllImagesAsync()
        {
            return await _dbContext.IndexImages.ToListAsync();
        }
        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
