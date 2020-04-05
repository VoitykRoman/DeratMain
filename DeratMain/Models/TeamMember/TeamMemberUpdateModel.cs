using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.TeamMember
{
    public class TeamMemberUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
        public string ImageUrl { get; set; }
    }
}
