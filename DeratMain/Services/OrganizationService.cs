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
        public async Task AddOrganizationAsync(OrganizationCreateModel  OrganizationCreateModel, string name)
        {
            var Organization = new Organization(OrganizationCreateModel, name);
            await _OrganizationRepository.AddOrganizationAsync(Organization, OrganizationCreateModel);
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await _OrganizationRepository.GetAllOrganizationsAsync();
        }

    }
}
