using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.EntityTypeConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(review => review.Id);

        builder
            .HasOne(review => review.Product)
            .WithMany(product => product.Reviews);
        builder
            .HasOne(review => review.User)
            .WithMany(user => user.Reviews);
        builder
            .Property(review => review.CreatedDate)
            .IsRequired();
    }
}
