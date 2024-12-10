using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.EntityTypeConfigurations;

public class OrderConfiguraion : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder
            .Property(order => order.Address)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(order => order.City)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(order => order.Country)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(order => order.Amount)
            .IsRequired();
        builder
            .Property(order => order.OrderTotal)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(order => order.CreatedDate)
            .IsRequired();
        builder
            .HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(user => user.UserId);
        builder
            .HasOne(order => order.Product);
    }
}

