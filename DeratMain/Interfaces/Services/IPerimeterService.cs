using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IPerimeterService
    {
        Task<IEnumerable<Perimeter>> GetAllPerimetersAsync();

        Task AddPerimeterAsync(PerimeterCreateModel Perimeter, string name);
    }
}
