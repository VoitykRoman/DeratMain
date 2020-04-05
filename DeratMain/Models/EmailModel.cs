using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Models
{
    public class EmailModel
    {
        public IEnumerable<string> Emails { get; set; }
        public string Content { get; set; }
    }
}
