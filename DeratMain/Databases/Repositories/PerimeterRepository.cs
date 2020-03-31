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
    public class PerimeterRepository : IPerimeterRepository
    {
        private readonly MainDbContext _dbContext;

        public PerimeterRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPerimeterAsync(Perimeter Perimeter, PerimeterCreateModel PerimeterCreateModel)
        {
            if (PerimeterCreateModel.EmployeeId.HasValue)
            {
                Perimeter.Employee = await _dbContext.Users
                    .FirstOrDefaultAsync(e => e.Id == PerimeterCreateModel.EmployeeId.Value);
            }
            Perimeter.Facility = await _dbContext.Facilities
                .FirstOrDefaultAsync(e => e.Id == PerimeterCreateModel.FacilityId);

            _dbContext.Perimeters.Add(Perimeter);
            await SaveChanges();
        }

        public async Task<IEnumerable<Perimeter>> GetAllPerimetersAsync()
        {
            return await _dbContext.Perimeters
                .Where(e => !e.IsDeleted)
                .Include(w => w.Facility)
                .Include(q => q.Traps)
                .Include(r => r.Employee)
                .ToListAsync();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
