using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IFacilityService
    {
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();

        Task AddFacilityAsync(FacilityCreateModel Facility, string name);

        Task<Facility> GetFacilityById(int id, int userId);

        Task DeleteFacility(int id);
    }
}
