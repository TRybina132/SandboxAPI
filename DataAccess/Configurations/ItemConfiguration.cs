using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasKey(item => item.Id);

            builder
                .Property(item => item.Name)
                .HasMaxLength(60);

            builder
                .HasOne(item => item.Delivery)
                .WithMany(delivery => delivery.Items)
                .HasForeignKey(item => item.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Items");
        }
    }
}
