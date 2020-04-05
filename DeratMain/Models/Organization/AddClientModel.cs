using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.Organization
{
    public class AddClientModel
    {
        public IEnumerable<int> ClientsIds { get; set; }
        public int OrganizationId { get; set; }

    }
}
