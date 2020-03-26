using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models;
using DeratMain.Models.TeamMember;
using System.Collections.Generic;
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

        public async Task DeleteTeamMemberAsync(int id)
        {
            await _teamMemberRepository.DeleteTeamMemberAsync(id);
        }

        public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync()
        {
            return await _teamMemberRepository.GetAllTeamMembersAsync();
        }

        public async Task<TeamMember> GetTeamMemberAsync(int id)
        {
            return await _teamMemberRepository.GetTeamMemberAsync(id);
        }

        public async Task UpdateTeamMemberAsync(TeamMemberUpdateModel teamMemberModel)
        {
            var itemToUpdate = await _teamMemberRepository
                .GetTeamMemberAsync(teamMemberModel.Id);

            itemToUpdate.Age = teamMemberModel.Age <= 0
                ? itemToUpdate.Age
                : teamMemberModel.Age;

            itemToUpdate.AvatarUrl = string.IsNullOrEmpty(teamMemberModel.AvatarUrl)
                ? itemToUpdate.AvatarUrl
                : teamMemberModel.AvatarUrl;

            itemToUpdate.Experience = teamMemberModel.Experience <= 0
                ? itemToUpdate.Experience
                : teamMemberModel.Experience;

            itemToUpdate.ImageUrl = string.IsNullOrEmpty(teamMemberModel.ImageUrl)
                ? itemToUpdate.ImageUrl
                : teamMemberModel.ImageUrl;

            itemToUpdate.Name = string.IsNullOrEmpty(teamMemberModel.Name)
                ? itemToUpdate.Name
                : teamMemberModel.Name;

            itemToUpdate.Phone = string.IsNullOrEmpty(teamMemberModel.Phone)
                ? itemToUpdate.Phone
                : teamMemberModel.Phone;

            itemToUpdate.Position = string.IsNullOrEmpty(teamMemberModel.Position)
                ? itemToUpdate.Position
                : teamMemberModel.Position;

            await _teamMemberRepository.UpdateTeamMemberAsync(itemToUpdate);
        }
    }
}
