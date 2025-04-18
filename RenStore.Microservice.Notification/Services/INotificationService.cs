namespace RenStore.Microservice.Notification.Services;

public interface INotificationService
{
    Task SendEmailAsync(string to, string subject, string body);
    Task SendSmsAsync(string phoneNumber, string message);
    Task SendPushAsync(string deviceToken, string message);
    Task AddNotificationAsync(Models.Notification notification, CancellationToken cancellationToken);
    Task UpdateNotificationAsync(Guid userId, CancellationToken cancellationToken);
    Task DeleteNotificationAsync(Guid userId, CancellationToken cancellationToken);
    Task<Models.Notification> GetNotificationAsync(Guid userId, CancellationToken cancellationToken);
}