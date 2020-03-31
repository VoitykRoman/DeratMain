
using DeratMain.Databases.Entities;
using DeratMain.Databases.Entities.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratMain.Databases.Configuration
{
    public class TrapConfiguration : BaseEntityConfiguration<Trap>
    {
        public override void Configure(EntityTypeBuilder<Trap> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.Perimeter).WithMany(e => e.Traps).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
