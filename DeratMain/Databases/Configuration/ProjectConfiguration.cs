using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.Organization).WithMany(o => o.Projects).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.Events).WithOne(o => o.Project).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
