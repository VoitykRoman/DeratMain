using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;

namespace DeratMain.Services
{
    public class PerimeterService : IPerimeterService
    {
        private readonly IPerimeterRepository _PerimeterRepository;

        public PerimeterService(IPerimeterRepository PerimeterRepository)
        {
            _PerimeterRepository = PerimeterRepository;
        }
        public async Task AddPerimeterAsync(PerimeterCreateModel  PerimeterCreateModel, string name)
        {
            var Perimeter = new Perimeter(PerimeterCreateModel, name);
            await _PerimeterRepository.AddPerimeterAsync(Perimeter, PerimeterCreateModel);
        }

        public async Task<IEnumerable<Perimeter>> GetAllPerimetersAsync()
        {
            return await _PerimeterRepository.GetAllPerimetersAsync();
        }

    }
}
