using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(l => l.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(n => n.FirstName)
                .HasMaxLength(50);

            builder.Property(n => n.LastName)
                .HasMaxLength(50);

            builder.Property(p => p.Phone)
                .HasMaxLength(50);

            builder.Property(c => c.Country)
                .HasMaxLength(50);

            builder.Property(c => c.City)
                .HasMaxLength(50);
        }
    }
}
