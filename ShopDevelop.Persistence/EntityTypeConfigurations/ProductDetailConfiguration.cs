using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.EntityTypeConfigurations;

public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        builder.HasKey(detail => detail.Id);

        builder
            .HasOne(detail => detail.Product)
            .WithOne(product => product.Details);
        builder
            .Property(details => details.Composition)
            .HasMaxLength(50)
            .IsRequired();
    }
}

