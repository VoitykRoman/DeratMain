using DeratMain.Models;

namespace DeratMain.Databases.Entities
{
    public class TeamMember : BaseEntity
    {
        public TeamMember(TeamMemberCreateModel teamMemberCreateModel) : base()
        {
            Name = teamMemberCreateModel.Name;
            Age = teamMemberCreateModel.Age;
            Position = teamMemberCreateModel.Position;
            Phone = teamMemberCreateModel.Phone;
            Experience = teamMemberCreateModel.Experience;
            AvatarUrl = teamMemberCreateModel.AvatarUrl;
            ImageUrl = teamMemberCreateModel.ImageUrl;
        }

        public TeamMember()
        {
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
        public string AvatarUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}
