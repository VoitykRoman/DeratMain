using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Configuration
{
    public class TeamMemberConfiguration : BaseEntityConfiguration<TeamMember>
    {
        public override void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Position).IsRequired();
        }
    }
}
