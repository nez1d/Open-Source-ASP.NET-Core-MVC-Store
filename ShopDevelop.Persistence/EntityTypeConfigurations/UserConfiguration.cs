using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder
                .Property(user => user.Login)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.Password)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.Patronymic)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(user => user.Phone)
                .HasMaxLength(25)
                .IsRequired();
            builder
                .Property(user => user.Role)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.Country)
                .HasMaxLength(50)
                .IsRequired(); 
            builder
                .Property(user => user.City)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.Balance)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(user => user.CreatedDate)
                .IsRequired();
            builder
                .Property(user => user.ImagePath)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .Property(user => user.ImagePath)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .Property(user => user.ImageFooterPath)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .HasMany(user => user.Reviews)
                .WithOne(review => review.User)
                .HasForeignKey(review => review.UserId);
            builder
                .HasMany(user => user.Reviews)
                .WithOne(review => review.User)
                .HasForeignKey(review => review.UserId);
            builder
                .HasMany(user => user.Reviews)
                .WithOne(review => review.User)
                .HasForeignKey(review => review.UserId);
            builder
                .HasMany(user => user.CartItems);
            builder
                .HasMany(user => user.Orders)
                .WithOne(review => review.User)
                .HasForeignKey(review => review.UserId);
        }
    }
}
