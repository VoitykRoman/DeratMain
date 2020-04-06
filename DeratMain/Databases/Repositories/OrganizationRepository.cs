using DeratMain.Databases.Entities;
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

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync(int id)
        {
            var user = await _dbContext.Users.AsNoTracking().Include(q => q.Organization)
                .ThenInclude(y => y.Facilities)
               .Include(a => a.Organization).ThenInclude(z => z.Projects)
               .Include(g => g.Organization).ThenInclude(n => n.Clients)
               .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (user.Role == "admin")
            {
                return await _dbContext.Organizations.AsNoTracking().Where(r => !r.IsDeleted)
                    .Include(e => e.Clients)
                    .Include(q => q.Facilities)
                    .Include(w => w.Projects)
                    .AsNoTracking()
                    .ToListAsync();
            }
            if (user.Organization != null)
            {
                return new List<Organization>()
            {
                user.Organization
            };
            }
            else
            {
                return new List<Organization>();
            }


        }

        public async Task<Organization> GetOrganizationById(int id)
        {
            return await _dbContext.Organizations
                .AsNoTracking()
                .Include(e => e.Clients)
                .Include(w => w.Facilities)
                .Include(q => q.Projects)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task DeleteFacility(int id)
        {
            var facility = await _dbContext.Facilities.FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Remove(facility);
            await SaveChanges();

        }

        public async Task RemoveClient(int clientId, int organizationId)
        {
            var client = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == clientId);
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(e => e.Id == organizationId);

            organization.Clients.Remove(client);
            await SaveChanges();
        }

        public async Task AddClient(IEnumerable<int> clientsId, int organizationId)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(e => e.Id == organizationId);
            foreach (var clientId in clientsId)
            {
                var client = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == clientId);
                organization.Clients.Add(client);
            }


            await SaveChanges();
        }

        public async Task DeleteOrganization(int id)
        {
            var org = await _dbContext.Organizations.Include(e => e.Projects).Include(e => e.Clients).FirstOrDefaultAsync(e => e.Id == id);
            

            foreach (var client in org.Clients)
            {
                client.Organization = null;
            }

            foreach (var pr in org.Projects)
            {
                pr.Organization = null;
            }
            org.Projects = null;
            _dbContext.Organizations.Remove(org);
            await SaveChanges();
        }
        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
