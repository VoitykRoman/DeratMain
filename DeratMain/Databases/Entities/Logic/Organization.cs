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
            AvatarUrl = organizationCreateModel.AvatarUrl;
        }

        public Organization() : base()
        {
        }

        public string Name { get; set; }
        public ICollection<Facility> Facilities { get; set; } = new List<Facility>();
        public ICollection<User> Clients { get; set; } = new List<User>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public string AvatarUrl { get; set; }

    }
}
