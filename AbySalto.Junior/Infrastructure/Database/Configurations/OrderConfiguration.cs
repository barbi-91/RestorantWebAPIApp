using AbySalto.Junior.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbySalto.Junior.Infrastructure.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary key
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(o => o.OrderTime)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETDATE()"); // Default to current date/time in SQL

            builder.Property(o => o.PaymentMethod)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(o => o.DeliveryAddress)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(o => o.ContactNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(o => o.Note)
                .HasMaxLength(500);

            builder.Property(o => o.Currency)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(3);

            // Relationship with OrderItem: Order has many OrderItems
            builder.HasMany(o => o.Items)
                   .WithOne(i => i.Order)
                   .HasForeignKey(i => i.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Ignore TotalAmount property for EF Core and mapping
            builder.Ignore(o => o.TotalAmount);
        }
    }
}
