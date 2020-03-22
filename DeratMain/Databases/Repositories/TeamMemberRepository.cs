using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Databases.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly MainDbContext _dbContext;

        public TeamMemberRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTeamMemberAsync(TeamMember teamMember)
        {
            await _dbContext.TeamMembers.AddAsync(teamMember);
            await SaveChanges();

        }

        public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync()
        {
            return await _dbContext.TeamMembers.ToListAsync();
        }

        public async Task<TeamMember> GetTeamMemberAsync(int id)
        {
           return await _dbContext.TeamMembers.FirstOrDefaultAsync(t => t.Id == id);
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
