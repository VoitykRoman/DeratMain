using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.Project
{
    public class AddEmployeesToProject
    {
        public IEnumerable<int> EmployeesIds { get; set; }

        public int ProjectId { get; set; }
    }
}
