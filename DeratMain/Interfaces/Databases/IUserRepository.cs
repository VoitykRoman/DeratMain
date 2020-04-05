using DeratMain.Databases.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(string email, string password);

        Task AddUserAsync(User user);

        Task<IEnumerable<User>> GetAllEmployeesAsync();

        Task<IEnumerable<User>> GetAllClientsAsync();

        Task UpdateUser();

        Task<User> GetUserById(int id);

        Task DeleteUser(int id);
    }
}
