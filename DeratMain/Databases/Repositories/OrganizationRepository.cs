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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly MainDbContext _dbContext;

        public OrganizationRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrganizationAsync(Organization organization, OrganizationCreateModel OrganizationCreateModel)
        {
            organization.Clients = await _dbContext.Users
                .Where(e => OrganizationCreateModel.Clients.Contains(e.Id))
                .ToListAsync();

            _dbContext.Organizations.Add(organization);
            await SaveChanges();
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await _dbContext.Organizations.Where(r => !r.IsDeleted)
                .Include(e => e.Clients)
                .Include(q => q.Facilities)
                .Include(w => w.Projects)
                .ToListAsync();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
