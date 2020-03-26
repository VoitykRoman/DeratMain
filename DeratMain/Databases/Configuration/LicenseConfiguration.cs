using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class LicenseConfiguration : BaseEntityConfiguration<License>
    {
        public override void Configure(EntityTypeBuilder<License> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ImageUrl).IsRequired();
        }
    }
}
