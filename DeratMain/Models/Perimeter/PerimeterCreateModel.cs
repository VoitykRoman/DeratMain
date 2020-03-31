using System.Collections.Generic;

namespace DeratMain.Models.Project
{
    public class PerimeterCreateModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? EmployeeId { get; set; }
        public string Service { get; set; }
        public int FacilityId { get; set; }
    }
}
