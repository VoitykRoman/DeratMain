
using DeratMain.Databases.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Email).IsRequired();

            builder.HasMany(e => e.Perimeters).WithOne(e => e.Employee);
            builder.HasOne(e => e.Organization).WithMany(e => e.Clients);
            builder.HasMany(e => e.Traps).WithOne(e => e.Employee);
            builder.HasOne(e => e.Feedback).WithOne(e => e.User).HasForeignKey<Feedback>(e => e.UserId);
        }
    }
}
