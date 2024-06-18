using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            dbId => ProductId.Of(dbId)); // Tells EF how to convert between ProductId and the underlying type
        
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
    }
}