using CleanArthitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArthitecture.Infrastructure.Persistence.Configure
{
    public class PaymentConfigure : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
           builder
        .HasOne(o => o.Order)
        .WithOne(p => p.Payment)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
