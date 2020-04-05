using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class PerimeterConfiguration : BaseEntityConfiguration<Perimeter>
    {
        public override void Configure(EntityTypeBuilder<Perimeter> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.Facility).WithMany(e => e.Perimeters).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Traps).WithOne(e => e.Perimeter).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Employee).WithMany(e => e.Perimeters).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
