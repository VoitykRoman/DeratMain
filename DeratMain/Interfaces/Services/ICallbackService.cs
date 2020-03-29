using DeratMain.Databases.Entities;
using DeratMain.Models.Callback;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface ICallbackService
    {
        Task<IEnumerable<Callback>> GetAllCallbacksAsync();

        Task<Callback> GetCallbackAsync(int id);

        Task AddCallbackAsync(CallbackCreateModel CallbackCreateModel);

        Task UpdateCallbackAsync(CallbackUpdateModel CallbackUpdateModel);

        Task DeleteCallbackAsync(int id);
    }
}
