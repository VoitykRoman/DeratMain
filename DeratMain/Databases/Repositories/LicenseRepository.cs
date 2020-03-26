using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Models.License;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly MainDbContext _dbContext;

        public LicenseRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddLicenseAsync(License license)
        {
            await _dbContext.Licenses.AddAsync(license);
            await SaveChanges();
        }

        public async Task DeleteLicenseAsync(int id)
        {
            var itemToDelete = await _dbContext.Licenses
                .FirstOrDefaultAsync(l => l.Id == id);

            itemToDelete.IsDeleted = true;
            await SaveChanges();
        }

        public async Task<IEnumerable<License>> GetAllLicensesAsync()
        {
            return await _dbContext.Licenses
                .Where(l => !l.IsDeleted).ToListAsync();
        }

        public async Task<License> GetLicenseAsync(int id)
        {
            return await _dbContext.Licenses
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateLicenseAsync(License license)
        {
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }


}
