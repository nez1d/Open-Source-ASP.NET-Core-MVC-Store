namespace RenStore.Microservice.Notification.Services;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
}