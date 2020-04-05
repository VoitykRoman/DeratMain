using DeratMain.Models.Project;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
namespace DeratMain.Databases.Entities.Logic
{
    public class Project : BaseEntity
    {

        public Project(ProjectCreateModel projectCreateModel, string name) : base()
        {
            Name = projectCreateModel.Name;
            Services = projectCreateModel.Services;
            OrganizationId = projectCreateModel.OrganizationId;
            Status = "pending";
            Events.Add(new Event($"Project has been created by {name} at {this.CreatedAt}", this));
            this.CreatedBy = name;
            AvatarUrl = projectCreateModel.AvatarUrl;
        }

        public Project() : base()
        {

        }
        public string Name { get; set; }
        public string Services { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public ICollection<EmployeeProject> EmployeesLnk { get; set; } = new List<EmployeeProject>();
        public string Status { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public string AvatarUrl { get; set; }
    }

    public class ProjectStatus
    {
        public const string Active = "active";
        public const string Pending = "pending";
        public const string Closed = "closed";
    }
}
