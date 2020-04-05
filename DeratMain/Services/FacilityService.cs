using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;

namespace DeratMain.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _FacilityRepository;

        public FacilityService(IFacilityRepository FacilityRepository)
        {
            _FacilityRepository = FacilityRepository;
        }
        public async Task AddFacilityAsync(FacilityCreateModel  FacilityCreateModel, string name)
        {
            var Facility = new Facility(FacilityCreateModel, name);
            await _FacilityRepository.AddFacilityAsync(Facility, FacilityCreateModel);
        }

        public async Task<IEnumerable<Facility>> GetAllFacilitiesAsync()
        {
            return await _FacilityRepository.GetAllFacilitiesAsync();
        }

        public async Task<Facility> GetFacilityById(int id, int userId)
        {
            return await _FacilityRepository.GetFacilityById(id, userId);
        }

        public async Task DeleteFacility(int id)
        {
            await _FacilityRepository.DeleteFacility(id);
        }
    }
}
