using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Entities
{
    public class IndexImage : BaseEntity
    {
        public string ImageUrl { get; set; }

    }
}
