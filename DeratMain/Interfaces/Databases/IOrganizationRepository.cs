using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync();

        Task AddOrganizationAsync(Organization Organization, OrganizationCreateModel OrganizationCreateModel);
    }
}
