using DeratMain.Databases.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface ICallbackRepository
    {
        Task<IEnumerable<Callback>> GetAllCallbacksAsync();

        Task<Callback> GetCallbackAsync(int id);

        Task AddCallbackAsync(Callback license);

        Task UpdateCallbackAsync(Callback license);

        Task DeleteCallbackAsync(int id);
    }
}
