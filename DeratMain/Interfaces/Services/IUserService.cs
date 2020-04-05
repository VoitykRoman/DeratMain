using DeratMain.Databases.Entities;
using DeratMain.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(string email, string password);

        Task AddUserAsync(UserCreateModel user);

        Task<IEnumerable<User>> GetAllEmployeesAsync();

        Task<IEnumerable<User>> GetAllClientsAsync();

        Task UpdateUser(UserUpdateModel userUpdateModel);

        //Task<User> GetUserById(int id);

        Task DeleteUser(int id);
    }
}
