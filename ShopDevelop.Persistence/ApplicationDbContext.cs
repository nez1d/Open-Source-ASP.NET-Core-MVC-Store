using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Domain.Models;
using ShopDevelop.Persistence.EntityTypeConfigurations;

namespace ShopDevelop.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
