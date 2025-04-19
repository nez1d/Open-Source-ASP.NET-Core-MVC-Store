using RenStore.Microservice.Notification.Enums;

namespace RenStore.Microservice.Notification.Repository;

public interface INotificationRepository
{
    Task AddNotificationAsync(Models.Notification notification, CancellationToken cancellationToken);
    Task UpdateStatusAsync(Guid id, NotificationStatus status, CancellationToken cancellationToken);
    Task DeleteNotificationAsync(Guid userId, CancellationToken cancellationToken);
    Task<Models.Notification> GetNotificationAsync(Guid userId, CancellationToken cancellationToken);
    Task<Models.Notification?> GetUserNotificationsAsync(Guid userId, CancellationToken cancellationToken);
}