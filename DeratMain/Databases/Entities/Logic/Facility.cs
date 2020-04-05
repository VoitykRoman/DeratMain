using DeratMain.Models.Project;
using System.Collections.Generic;

namespace DeratMain.Databases.Entities.Logic
{
    public class Facility : BaseEntity
    {

        public Facility(FacilityCreateModel facilityCreateModel, string name) : base()
        {
            Name = facilityCreateModel.Name;
            Address = facilityCreateModel.Address;
            CreatedBy = name;

        }

        public Facility() : base()
        {

        }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Perimeter> Perimeters { get; set; } = new List<Perimeter>();
        public Organization Organization { get; set; }
    }
}
