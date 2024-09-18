using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveShangesAsync(CancellationToken cancellationToken);
        DbSet<User> Users { get; set; }
    }
}
