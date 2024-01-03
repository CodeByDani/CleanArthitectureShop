using CleanArthitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArthitecture.Infrastructure.Persistence.Configure
{
    public class OrderConfigure : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
           .HasOne(o => o.Payment)
           .WithOne(p => p.Order)
           .HasForeignKey<Payment>(p => p.OrderID)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
