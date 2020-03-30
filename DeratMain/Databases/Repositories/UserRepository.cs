using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _dbContext;

        public UserRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await SaveChanges();
        }

        public async Task DeleteUserAsync(int id)
        {
            var itemToDelete = await _dbContext.Users
                .FirstOrDefaultAsync(l => l.Id == id);

            itemToDelete.IsDeleted = true;
            await SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users
                .Where(l => !l.IsDeleted).ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<IEnumerable<User>> GetUsersByRole(string role)
        {
            return await _dbContext.Users.Where(u => u.Role == role).ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
