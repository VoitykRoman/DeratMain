using System;
using System.Collections.Generic;

namespace DeratMain.Models.Callback
{
    public class CallbackUpdateModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Services { get; set; } = new List<string>();
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
