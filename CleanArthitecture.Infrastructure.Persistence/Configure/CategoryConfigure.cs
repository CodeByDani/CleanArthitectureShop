using CleanArthitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArthitecture.Infrastructure.Persistence.Configure;

public class CategoryConfigure : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasIndex(p => p.Name).IsUnique();
    }
}