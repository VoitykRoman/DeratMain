using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Configuration
{
    public class IndexImageConfiguration : BaseEntityConfiguration<IndexImage>
    {
        public override void Configure(EntityTypeBuilder<IndexImage> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ImageUrl).IsRequired();
        }
    }
}
