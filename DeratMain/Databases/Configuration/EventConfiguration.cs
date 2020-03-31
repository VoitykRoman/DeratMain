
using DeratMain.Databases.Entities;
using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class EventConfiguration : BaseEntityConfiguration<Event>
    {
        public override void Configure(EntityTypeBuilder<Event> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.Project).WithMany(e => e.Events).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
