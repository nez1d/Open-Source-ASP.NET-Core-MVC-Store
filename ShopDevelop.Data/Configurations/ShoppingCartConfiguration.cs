/*using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder.
                HasMany(s => s.ShoppingCartItems);
        }
    }
}
*/