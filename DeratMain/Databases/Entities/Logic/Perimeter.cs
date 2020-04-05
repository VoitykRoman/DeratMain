﻿using DeratMain.Models.Project;
using System;
using System.Collections.Generic;

namespace DeratMain.Databases.Entities.Logic
{
    public class Perimeter : BaseEntity
    {

        public Perimeter(PerimeterCreateModel perimeterCreateModel, string name) : base()
        {
            Type = perimeterCreateModel.Type;
            Name = perimeterCreateModel.Name;
            Service = perimeterCreateModel.Service;
            CreatedBy = name;
            Status = "pending";
            LastAction = CreatedAt;
        }

        public Perimeter() : base()
        {

        }
        public string Type { get; set; }
        public ICollection<Trap> Traps { get; set; }
        public Facility Facility { get; set; }
        public string Name { get; set; }
        public User Employee { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }
        public DateTime LastAction { get; set; }
    }
}
