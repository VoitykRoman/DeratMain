using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync(int id);

        Task AddOrganizationAsync(OrganizationCreateModel Organization, string name);

        Task<Organization> GetOrganizationById(int id);

        Task DeleteFacility(int facilityId);

        Task RemoveClient(int clientId, int organizationId);

        Task AddClient(IEnumerable<int> clientsId, int organizationId);

        Task DeleteOrganization(int id);
    }
}
