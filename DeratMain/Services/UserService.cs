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

        public async Task<IEnumerable<User>> GetAllEmployeesAsync()
        {
            return await _UserRepository.GetAllEmployeesAsync();
        }

        public async Task<IEnumerable<User>> GetAllClientsAsync()
        {
            return await _UserRepository.GetAllClientsAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _UserRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            return await _UserRepository.GetUserAsync(email, password);
        }

        public async Task UpdateUser(UserUpdateModel userUpdateModel)
        {
            var userToUpdate = await _UserRepository.GetUserById(userUpdateModel.UserId);

            userToUpdate.Email = string.IsNullOrEmpty(userUpdateModel.Email)
                ? userToUpdate.Email
                : userUpdateModel.Email;

            userToUpdate.FirstName = string.IsNullOrEmpty(userUpdateModel.FirstName)
    ? userToUpdate.FirstName
    : userUpdateModel.FirstName;

            userToUpdate.LastName = string.IsNullOrEmpty(userUpdateModel.LastName)
    ? userToUpdate.LastName
    : userUpdateModel.LastName;

            userToUpdate.Password = string.IsNullOrEmpty(userUpdateModel.Password)
    ? userToUpdate.Password
    : userUpdateModel.Password;

            userToUpdate.Phone = string.IsNullOrEmpty(userUpdateModel.Phone)
    ? userToUpdate.Phone
    : userUpdateModel.Phone;

            userToUpdate.AvatarUrl = string.IsNullOrEmpty(userUpdateModel.AvatarUrl)
? userToUpdate.AvatarUrl
: userUpdateModel.AvatarUrl;

            await _UserRepository.UpdateUser();
        }

        public async Task DeleteUser(int id)
        {
            await _UserRepository.DeleteUser(id);
        }
    }
}
