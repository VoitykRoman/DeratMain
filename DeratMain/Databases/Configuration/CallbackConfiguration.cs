
using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class CallbackConfiguration : BaseEntityConfiguration<Callback>
    {
        public override void Configure(EntityTypeBuilder<Callback> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Phone).IsRequired();
            builder.Property(e => e.FullName).IsRequired();
        }
    }
}
