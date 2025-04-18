using Microsoft.EntityFrameworkCore;
using RenStore.Microservice.Notification.Configs;
using RenStore.Microservice.Notification.Models;

namespace RenStore.Microservice.Notification.Data;

public class NotificationDbContext : DbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }
    
    /*public DbSet<LogEntity> Logs { get; set; }*/
    public DbSet<Models.Notification> Notifications { get; set; }
}