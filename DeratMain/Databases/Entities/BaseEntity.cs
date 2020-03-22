using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = new DateTime();
        }
        public virtual int Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedAt { get; set; }

    }
}
