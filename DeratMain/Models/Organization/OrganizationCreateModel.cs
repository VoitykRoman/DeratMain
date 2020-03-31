using System.Collections.Generic;

namespace DeratMain.Models.Project
{
    public class OrganizationCreateModel
    {
        public string Name { get; set; }
        public ICollection<int> Clients { get; set; }
    }
}
