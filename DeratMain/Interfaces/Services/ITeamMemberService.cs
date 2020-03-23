using DeratMain.Databases.Entities;
using DeratMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface ITeamMemberService
    {
        Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();

        Task<TeamMember> GetTeamMemberAsync(int id);

        Task AddTeamMemberAsync(TeamMemberCreateModel teamMemberModel);
    }
}
