using Data.Infrastructure;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class OrderMap : EntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Id).ValueGeneratedOnAdd();

            builder.HasOne(item => item.User)
                .WithMany()
                .HasForeignKey(item => item.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(item => item.OrderNumber).HasMaxLength(100).IsRequired();
        }
    }
}