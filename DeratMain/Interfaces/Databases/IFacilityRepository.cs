using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IFacilityRepository
    {
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();

        Task AddFacilityAsync(Facility Facility, FacilityCreateModel FacilityCreateModel);

        Task<Facility> GetFacilityById(int id, int userId);

        Task DeleteFacility(int id);
    }
}
