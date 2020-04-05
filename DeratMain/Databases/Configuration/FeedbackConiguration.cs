
using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Databases.Configuration
{
    public class FeedbackConfiguration : BaseEntityConfiguration<Feedback>
    {
        public override void Configure(EntityTypeBuilder<Feedback> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.UserName).IsRequired();
            builder.Property(e => e.Rating).IsRequired();
            builder.HasOne(e => e.User).WithOne(e => e.Feedback);
            //builder.HasOne(e => e.User).WithOne(e => e.Feedback).HasForeignKey(e => e.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
