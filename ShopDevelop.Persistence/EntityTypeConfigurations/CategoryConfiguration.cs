using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.EntityTypeConfigurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);

        builder
            .Property(category => category.Name)
            .HasMaxLength(25)
            .IsRequired();
        builder
            .Property(category => category.Description)
            .HasMaxLength(150)
            .IsRequired();
        builder
            .Property(category => category.ImagePath)
            .HasMaxLength(250)
            .IsRequired();
        builder
            .HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.CategoryId);
    }
}