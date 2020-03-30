using DeratMain.Databases.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<User> GetUserAsync(string email, string password);

        Task<IEnumerable<User>> GetUsersByRole(string role);

        Task AddUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);
    }
}
