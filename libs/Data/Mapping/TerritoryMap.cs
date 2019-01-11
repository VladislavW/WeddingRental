using Data.Infrastructure;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class TerritoryMap : EntityConfiguration<Territory>
    {
        public override void Configure(EntityTypeBuilder<Territory> builder)
        {
            builder.ToTable("Territory");
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
            
            builder.Property(item => item.CountryName).HasMaxLength(100).IsRequired();
        }
    }
}