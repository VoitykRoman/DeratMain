using DeratMain.Databases.Entities;
using DeratMain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface ITeamMemberRepository
    {
        Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();

        Task<TeamMember> GetTeamMemberAsync(int id);

        Task AddTeamMemberAsync(TeamMember teamMember);
    }
}
