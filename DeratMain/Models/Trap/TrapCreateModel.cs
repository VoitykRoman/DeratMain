using DeratMain.Databases.Entities.Logic;
using System.Collections.Generic;

namespace DeratMain.Models.Project
{
    public class TrapCreateModel
    {
        public string Type { get; set; }
        public string Comment { get; set; }
        public string Place { get; set; }
        public int PerimeterId { get; set; }
        public int EmployeeId { get; set; }
        public int LifeInDays { get; set; }

        public int ReviewEveryDays { get; set; }
    }
}
