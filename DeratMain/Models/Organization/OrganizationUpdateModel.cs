﻿using DeratMain.Databases.Entities.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.Project
{
    public class OrganizationUpdateModel
    {
        public string Name { get; set; }
        public ICollection<string> Services { get; set; }
        public Organization Organization { get; set; }
        public ICollection<DeratMain.Databases.Entities.User> Employees { get; set; }
        public string Status { get; set; }
    }
}
