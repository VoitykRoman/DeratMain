using DeratMain.Databases.Entities.Logic;
using System.Collections.Generic;

namespace DeratMain.Models.Project
{
    public class ProjectCreateModel
    {
        public string Name { get; set; }
        public string Services { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<int> Employees { get; set; } = new List<int>();
        public string AvatarUrl { get; set; }

    }
}
