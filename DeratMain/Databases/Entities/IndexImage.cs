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

        public static void Configure(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<IndexImage>();
            entity.HasKey(e => e.Id);
        }
    }
}
