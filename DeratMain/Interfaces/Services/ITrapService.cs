using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface ITrapService
    {
        Task<IEnumerable<Trap>> GetAllTrapsAsync();

        Task AddTrapAsync(TrapCreateModel Trap, string name);
    }
}
