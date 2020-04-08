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
            return await _dbContext.Facilities
                .AsNoTracking()
                .Where(r => !r.IsDeleted)
                .Include(e => e.Organization)
                .Include(q => q.Perimeters)
                .ToListAsync();
        }

        public async Task<Facility> GetFacilityById(int id, int userId)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Id == userId);

            if (user.Role != "employee")
            {
               return await _dbContext.Facilities.AsNoTracking()
                    .Include(q => q.Perimeters).ThenInclude(e => e.Employee)
                    .Include(w => w.Organization).ThenInclude(ww => ww.Projects).ThenInclude(www => www.EmployeesLnk).ThenInclude(t => t.Employee)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            else
            {
                facility.Perimeters = await _dbContext.Perimeters.AsNoTracking().Include(ee => ee.Employee).Include(e => e.Facility).Where(e => e.Employee.Id == user.Id && e.Facility.Id == id).ToListAsync();
                facility.Perimeters = await _dbContext.Perimeters.AsNoTracking().Include(ee => ee.Employee).Where(e => e.Employee.Id == user.Id).ToListAsync();
                return facility;
            }
        }
        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFacility(int id)
        {
            var facility = await _dbContext.Facilities.FirstOrDefaultAsync(e => e.Id == id);

            _dbContext.Facilities.Remove(facility);

            await SaveChanges();
        }
    }
}
