using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class OrganizationConfiguration : BaseEntityConfiguration<Organization>
    {
        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            base.Configure(builder);
            builder.HasMany(e => e.Projects).WithOne(e => e.Organization).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.Facilities).WithOne(e => e.Organization).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Clients).WithOne(e => e.Organization);
        }
    }
}
