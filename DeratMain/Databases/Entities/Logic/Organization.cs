using DeratMain.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Entities.Logic
{
    public class Organization : BaseEntity
    {
        public Organization(OrganizationCreateModel organizationCreateModel, string name) : base()
        {
            Name = organizationCreateModel.Name;
            CreatedBy = name;
        }

        public Organization() : base()
        {
        }

        public string Name { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public ICollection<User> Clients { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
