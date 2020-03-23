using DeratMain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }

        public TeamMember()
        {
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }

    }
}
