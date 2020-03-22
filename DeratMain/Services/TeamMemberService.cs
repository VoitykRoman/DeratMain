using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DeratMain.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }
        public async Task AddTeamMemberAsync(TeamMemberCreateModel teamMemberModel)
        {
            var teamMember = new TeamMember(teamMemberModel);
            await _teamMemberRepository.AddTeamMemberAsync(teamMember);
        }

        public Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeamMember> GetTeamMemberAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
