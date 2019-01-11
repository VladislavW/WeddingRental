using Core.Enums;
using Data.Infrastructure;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class OrderProductMap: EntityConfiguration<OrderProduct>
    {
        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");
            builder.HasKey(item => item.Id);
            
            builder.HasOne(item => item.Order)
                .WithMany()
                .HasForeignKey(item => item.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(item => item.Product)
                .WithMany()
                .HasForeignKey(item => item.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}