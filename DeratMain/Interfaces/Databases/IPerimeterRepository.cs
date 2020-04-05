using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IPerimeterRepository
    {
        Task<IEnumerable<Perimeter>> GetAllPerimetersAsync();

        Task AddPerimeterAsync(Perimeter Perimeter, PerimeterCreateModel PerimeterCreateModel);

        Task<Perimeter> GetPerimeterById(int id);

        Task SaveChanges();

        Task MarkAsReviewed(int id);

        Task DeletePerimeter(int id);

    }
}
