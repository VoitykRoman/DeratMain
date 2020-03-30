using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.User;
using DeratMain.Models.License;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async Task AddUserAsync(UserCreateModel UserCreateModel)
        {
            var User = new User(UserCreateModel);
            await _UserRepository.AddUserAsync(User);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _UserRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _UserRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _UserRepository.GetUserAsync(id);
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            return await _UserRepository.GetUserAsync(email, password);
        }

        public async Task<IEnumerable<User>> GetUsersByRole(string role)
        {
            return await _UserRepository.GetUsersByRole(role);
        }

        public async Task UpdateUserAsync(UserUpdateModel UserUpdateModel, int id)
        {
            var itemToUpdate = await _UserRepository
                .GetUserAsync(id);

            itemToUpdate.Email = string.IsNullOrEmpty(UserUpdateModel.Email)
                ? itemToUpdate.Email
                : UserUpdateModel.Email;

            itemToUpdate.Password = string.IsNullOrEmpty(UserUpdateModel.Password)
               ? itemToUpdate.Password
               : UserUpdateModel.Password;

            itemToUpdate.Role = string.IsNullOrEmpty(UserUpdateModel.Role)
               ? itemToUpdate.Role
               : UserUpdateModel.Role;

            itemToUpdate.FirstName = string.IsNullOrEmpty(UserUpdateModel.FirstName)
   ? itemToUpdate.FirstName
   : UserUpdateModel.FirstName;

            itemToUpdate.LastName = string.IsNullOrEmpty(UserUpdateModel.LastName)
   ? itemToUpdate.LastName
   : UserUpdateModel.LastName;


            itemToUpdate.Phone = string.IsNullOrEmpty(UserUpdateModel.Phone)
? itemToUpdate.Phone
: UserUpdateModel.Phone;

            await _UserRepository.UpdateUserAsync(itemToUpdate);
        }
    }
}
