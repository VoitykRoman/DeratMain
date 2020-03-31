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
    public class TrapRepository : ITrapRepository
    {
        private readonly MainDbContext _dbContext;

        public TrapRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTrapAsync(Trap Trap, TrapCreateModel TrapCreateModel)
        {
            Trap.Employee = await _dbContext.Users
                .FirstOrDefaultAsync(e => e.Id == TrapCreateModel.EmployeeId &&
                                                  e.Role == "employee");
            Trap.Perimeter = await _dbContext.Perimeters
                .FirstOrDefaultAsync(e => e.Id == TrapCreateModel.PerimeterId);

            _dbContext.Traps.Add(Trap);
            await SaveChanges();
        }

        public async Task<IEnumerable<Trap>> GetAllTrapsAsync()
        {
            return await _dbContext.Traps
                 .Where(q => !q.IsDeleted)
                 .Include(w => w.Employee)
                 .Include(e => e.Perimeter)
                 .ToListAsync();
                  
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
