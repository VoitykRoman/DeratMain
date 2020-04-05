using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;

namespace DeratMain.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _OrganizationRepository;

        public OrganizationService(IOrganizationRepository OrganizationRepository)
        {
            _OrganizationRepository = OrganizationRepository;
        }
        public async Task AddOrganizationAsync(OrganizationCreateModel OrganizationCreateModel, string name)
        {
            var Organization = new Organization(OrganizationCreateModel, name);
            await _OrganizationRepository.AddOrganizationAsync(Organization, OrganizationCreateModel);
        }

        public async Task<Organization> GetOrganizationById(int id)
        {
            return await _OrganizationRepository.GetOrganizationById(id);
        }
        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync(int id)
        {
            return await _OrganizationRepository.GetAllOrganizationsAsync(id);
        }

        public async Task DeleteFacility(int id)
        {
            await _OrganizationRepository.DeleteFacility(id);
        }

        public async Task RemoveClient(int clientId, int organizationId)
        {
            await _OrganizationRepository.RemoveClient(clientId, organizationId);
        }

        public async Task AddClient(IEnumerable<int> clientsId, int organizationId)
        {
            await _OrganizationRepository.AddClient(clientsId, organizationId);
        }

        public async Task DeleteOrganization(int id)
        {
            await _OrganizationRepository.DeleteOrganization(id);
        }

    }
}
