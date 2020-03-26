using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task DeleteTeamMemberAsync(int id)
        {
            var itemToDelete = await _dbContext.TeamMembers
                .FirstOrDefaultAsync(t => t.Id == id);
            if(itemToDelete == null)
            {
                throw new Exception($"Team member doesnt exist with id {id}");
            }
            itemToDelete.IsDeleted = true;

            await SaveChanges();
        }

        public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync()
        {
            return await _dbContext.TeamMembers.Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<TeamMember> GetTeamMemberAsync(int id)
        {
            return await _dbContext.TeamMembers.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateTeamMemberAsync(TeamMember teamMember)
        {
            await _dbContext.SaveChangesAsync();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
