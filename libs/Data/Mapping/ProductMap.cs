using Core.Enums;
using Data.Infrastructure;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ProductMap : EntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
            builder.Property(item => item.Number).HasMaxLength(100);
            builder.Property(item => item.Name).HasMaxLength(5000);
            builder.Property(item => item.Type).HasDefaultValue(ProductType.Dress);
            builder.Property(item => item.Color).HasDefaultValue(Color.White);
        }
    }
}