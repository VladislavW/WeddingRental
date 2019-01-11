using Data.Infrastructure;
using Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap : IdentityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            
            builder.HasOne(item => item.Territory)
                .WithMany()
                .HasForeignKey(item => item.TerritoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}