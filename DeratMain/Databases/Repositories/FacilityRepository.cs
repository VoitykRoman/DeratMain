using DeratMain.Databases.Entities.Logic;
using DeratMain.Interfaces.Databases;
using DeratMain.Models.Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly MainDbContext _dbContext;

        public FacilityRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFacilityAsync(Facility Facility, FacilityCreateModel FacilityCreateModel)
        {
            Facility.Organization = await _dbContext.Organizations
                .FirstOrDefaultAsync(e => e.Id == FacilityCreateModel.OrganizationId);

            _dbContext.Add(Facility);
            await SaveChanges();
        }

        public async Task<IEnumerable<Facility>> GetAllFacilitiesAsync()
        {
            return  await _dbContext.Facilities
                .Where(r => !r.IsDeleted)
                .Include(e => e.Organization)
                .Include(q => q.Perimeters)
                .ToListAsync();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
