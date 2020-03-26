using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.License
{
    public class LicenseCreateModel
    {
        public string Name { get; set; }
        public string IssuedBy { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string ReadMoreUrl { get; set; }
    }
}
