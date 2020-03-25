using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task DeleteIndexImageAsync(int id)
        {
            var item = await _dbContext.IndexImages.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                throw new Exception("Index image doesnt exist");
            }
            item.IsDeleted = true;
            await SaveChanges();
        }

        public async Task<IEnumerable<IndexImage>> GetAllImagesAsync()
        {
            return await _dbContext.IndexImages.Where(i => !i.IsDeleted)
                .ToListAsync();
        }

        public async Task<IndexImage> GetIndexImageAsync(int id)
        {
            return await _dbContext.IndexImages.
                FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateImageAsync(IndexImage image)
        {
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
