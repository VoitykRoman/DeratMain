using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models.Callback
{
    public class CallbackCreateModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Services { get; set; } = new List<string>();
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
