using ShopDevelop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopDevelop.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder
                .Property(prodcut => prodcut.Article)
                .HasMaxLength(9)
                .IsRequired();
            builder
                .Property(product => product.ProductName)
                .HasMaxLength(150)
                .IsRequired();
            builder
                .Property(product => product.Price)
                .HasMaxLength(15)
                .IsRequired();
            builder
                .Property(product => product.Description)
                .HasMaxLength(1000)
                .IsRequired();
            builder
                .Property(product => product.ShortDescription)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .Property(product => product.InStock)
                .HasMaxLength(10)
                .IsRequired();
            builder
                .Property(product => product.ImagePath)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .Property(product => product.ImageMiniPath)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .Property(product => product.Rating)
                .HasMaxLength(4)
                .IsRequired();
            builder
                .HasOne(product => product.Details)
                .WithOne(detail => detail.Product);
            builder
                .HasMany(product => product.Reviews)
                .WithOne(review => review.Product)
                .HasForeignKey(review => review.ProductId);
            builder
                .HasOne(product => product.Category)
                .WithMany(category => category.Products);
            builder
                .HasOne(product => product.Seller)
                .WithMany(seller => seller.Products);
        }
    }
}