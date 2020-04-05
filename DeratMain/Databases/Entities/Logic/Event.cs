using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Entities.Logic
{
    public class Event : BaseEntity
    {
        public Event(string text, Project project)
        {
            EventText = text;
            Project = project;
        }

        public Event()
        {

        }
        public string EventText { get; set; }
        public Project Project { get; set; }
    }
}
