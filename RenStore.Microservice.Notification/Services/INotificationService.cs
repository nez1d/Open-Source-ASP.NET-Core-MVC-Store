using RenStore.Microservice.Notification.Common.Result;

namespace RenStore.Microservice.Notification.Services;

public interface INotificationService
{
    Task<Result> SendEmailAsync(Guid userId, string email, string subject, string body);
    Task SendSmsAsync(string phoneNumber, string message);
    Task SendPushAsync(string deviceToken, string message);
}