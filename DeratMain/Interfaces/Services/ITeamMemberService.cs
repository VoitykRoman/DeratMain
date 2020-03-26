using DeratMain.Databases.Entities;
using DeratMain.Models;
using DeratMain.Models.TeamMember;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface ITeamMemberService
    {
        Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();

        Task<TeamMember> GetTeamMemberAsync(int id);

        Task AddTeamMemberAsync(TeamMemberCreateModel teamMemberModel);

        Task UpdateTeamMemberAsync(TeamMemberUpdateModel teamMemberModel);

        Task DeleteTeamMemberAsync(int id);
    }
}
