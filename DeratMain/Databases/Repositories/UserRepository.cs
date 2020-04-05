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

        public async Task<IEnumerable<User>> GetAllEmployeesAsync()
        {
            return await _dbContext.Users.AsNoTracking().Where(e => !e.IsDeleted &&
                                                     e.Role == "employee")
                .ToListAsync();

        }

        public async Task<IEnumerable<User>> GetAllClientsAsync()
        {
            return await _dbContext.Users.AsNoTracking().Where(e => !e.IsDeleted &&
                                                     e.Role == "client")
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.AsNoTracking()
                .Where(l => !l.IsDeleted).ToListAsync();
        }
        public async Task<User> GetUserAsync(string email, string password)
        {
            return await _dbContext.Users.Include(e => e.Organization).AsNoTracking().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }


        public async Task UpdateUser()
        {
            await SaveChanges();
        }

        public async Task<User> GetUserById(int id)
        {   
            return await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Users.Remove(user);

            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
