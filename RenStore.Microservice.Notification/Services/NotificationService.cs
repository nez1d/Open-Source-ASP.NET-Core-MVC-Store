using RenStore.Microservice.Notification.Common.Result;
using RenStore.Microservice.Notification.Enums;
using RenStore.Microservice.Notification.Repository;

namespace RenStore.Microservice.Notification.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> logger;
    private readonly IEmailNotificationSender emailNotificationSender;
    private readonly INotificationRepository notificationRepository;
    
    public NotificationService(
        ILogger<NotificationService> logger, 
        IEmailNotificationSender emailNotificationSender,
        INotificationRepository notificationRepository)
    {
        this.logger = logger;
        this.emailNotificationSender = emailNotificationSender;
        this.notificationRepository = notificationRepository;
    }
    
    public async Task<Result> SendEmailAsync(Guid userId, string to, string subject, string body)
    {
        logger.LogInformation($"Handling {nameof(NotificationService)}");
        
        var notify = await emailNotificationSender.SendEmailAsync(to, subject, body);
        
        if(notify.IsFailure)
            return Result.Failure(new Error("", ""));
        
        var notification = new Models.Notification
        {
            UserId = userId,
            Type = NotificationType.Email,
            Subject = subject,
            Content = body,
            Status = NotificationStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
        
        await notificationRepository.AddNotificationAsync(notification, CancellationToken.None);
        
        logger.LogInformation($"Handled {nameof(NotificationService)}");
        
        return Result.Success;
    }

    public async Task SendSmsAsync(string phoneNumber, string message)
    {
        throw new NotImplementedException();
    }

    public async Task SendPushAsync(string deviceToken, string message)
    {
        throw new NotImplementedException();
    }
}