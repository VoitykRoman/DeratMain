using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class FacilityConfiguration : BaseEntityConfiguration<Facility>
    {
        public override void Configure(EntityTypeBuilder<Facility> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.Organization).WithMany(e => e.Facilities).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Perimeters).WithOne(e => e.Facility).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
