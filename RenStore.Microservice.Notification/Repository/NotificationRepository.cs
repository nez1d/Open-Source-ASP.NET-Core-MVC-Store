using Microsoft.EntityFrameworkCore;
using RenStore.Microservice.Notification.Data;
using RenStore.Microservice.Notification.Enums;

namespace RenStore.Microservice.Notification.Repository;

public class NotificationRepository : INotificationRepository
{
    private readonly NotificationDbContext context;
    
    public NotificationRepository(NotificationDbContext context) => 
        this.context = context;
    
    public async Task AddNotificationAsync(Models.Notification notification, CancellationToken cancellationToken)
    {
        await context.Notifications.AddAsync(notification, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateStatusAsync(Guid id, NotificationStatus status, CancellationToken cancellationToken)
    {
    }
    
    public async Task DeleteNotificationAsync(Guid userId, CancellationToken cancellationToken)
    {
        var notification = await this.GetNotificationAsync(userId, cancellationToken);
        
        if (notification is null)
            return;
        
        context.Remove(notification);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Models.Notification?> GetNotificationAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Notifications
            .FirstOrDefaultAsync(notification => 
                    notification.Id == id,
                cancellationToken);
    }
    
    public async Task<Models.Notification?> GetUserNotificationsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await context.Notifications
            .FirstOrDefaultAsync(notification => 
                    notification.UserId == userId,
                cancellationToken);
    }
}