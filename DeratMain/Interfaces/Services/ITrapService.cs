using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface ITrapService
    {
        Task<IEnumerable<Trap>> GetAllTrapsAsync();

        Task<Trap> GetTrapById(int id);
        Task AddTrapAsync(TrapCreateModel Trap, string name);

        Task DeleteTrap(int id);

        Task MarkAsReviewed(int id);
    }
}
