using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.Callback;
using DeratMain.Models.License;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Services
{
    public class CallbackService : ICallbackService
    {
        private readonly ICallbackRepository _CallbackRepository;

        public CallbackService(ICallbackRepository CallbackRepository)
        {
            _CallbackRepository = CallbackRepository;
        }
        public async Task AddCallbackAsync(CallbackCreateModel  CallbackCreateModel)
        {
            var Callback = new Callback(CallbackCreateModel);
            await _CallbackRepository.AddCallbackAsync(Callback);
        }

        public async Task DeleteCallbackAsync(int id)
        {
            await _CallbackRepository.DeleteCallbackAsync(id);
        }

        public async Task<IEnumerable<Callback>> GetAllCallbacksAsync()
        {
            return await _CallbackRepository.GetAllCallbacksAsync();
        }

        public async Task<Callback> GetCallbackAsync(int id)
        {
            return await _CallbackRepository.GetCallbackAsync(id);
        }

        public async Task UpdateCallbackAsync(CallbackUpdateModel CallbackUpdateModel)
        {
            var itemToUpdate = await _CallbackRepository
                .GetCallbackAsync(CallbackUpdateModel.Id);

            itemToUpdate.FullName = string.IsNullOrEmpty(CallbackUpdateModel.FullName)
                ? itemToUpdate.FullName
                : CallbackUpdateModel.FullName;

            itemToUpdate.Email= string.IsNullOrEmpty(CallbackUpdateModel.Email)
               ? itemToUpdate.Email
               : CallbackUpdateModel.Email;

            itemToUpdate.Phone = string.IsNullOrEmpty(CallbackUpdateModel.Phone)
               ? itemToUpdate.Phone
               : CallbackUpdateModel.Phone;

            itemToUpdate.DateTime = CallbackUpdateModel.DateTime > itemToUpdate.DateTime 
               ? itemToUpdate.DateTime
               : CallbackUpdateModel.DateTime;

            itemToUpdate.Services = !CallbackUpdateModel.Services.Any()
              ? itemToUpdate.Services
              : string.Join(',', CallbackUpdateModel.Services);
            await _CallbackRepository.UpdateCallbackAsync(itemToUpdate);
        }
    }
}
