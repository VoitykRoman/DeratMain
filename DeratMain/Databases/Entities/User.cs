using DeratMain.Databases.Entities.Logic;
using DeratMain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Entities
{
    public class User : BaseEntity
    {
        public User(UserCreateModel userCreateModel) : base()
        {
            Email = userCreateModel.Email;
            Password = userCreateModel.Password;
            Role = userCreateModel.Role;
            FirstName = userCreateModel.FirstName;
            LastName = userCreateModel.LastName;
            Phone = userCreateModel.Phone;
        }

        public User() : base()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AvatarUrl { get; set; }
        public Organization Organization { get; set; }
        public ICollection<EmployeeProject> ProjectsLnk { get; set; } = new List<EmployeeProject>();
        public ICollection<Perimeter> Perimeters { get; set; } = new List<Perimeter>();
        public ICollection<Trap> Traps { get; set; } = new List<Trap>();
        public Feedback Feedback { get; set; }
    }
}
