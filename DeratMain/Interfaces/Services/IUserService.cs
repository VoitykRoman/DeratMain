using DeratMain.Databases.Entities;
using DeratMain.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<User> GetUserAsync(string email, string password);

        Task<IEnumerable<User>> GetUsersByRole(string role);

        Task AddUserAsync(UserCreateModel user);

        Task UpdateUserAsync(UserUpdateModel user, int id);

        Task DeleteUserAsync(int id);
    }
}
