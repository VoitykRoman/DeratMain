using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync();

        Task AddOrganizationAsync(OrganizationCreateModel Organization, string name);
    }
}
