using Microsoft.EntityFrameworkCore;
using RenStore.Microservice.Notification.Data;

namespace RenStore.Microservice.Notification.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> logger;
    private readonly IEmailService emailService;
    private readonly NotificationDbContext context;

    public NotificationService(
        ILogger<NotificationService> logger, 
        IEmailService emailService,
        NotificationDbContext context)
    {
        this.logger = logger;
        this.emailService = emailService;
        this.context = context;
    }
    
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        logger.LogInformation($"Handling {nameof(NotificationService)}");
        
        await emailService.SendEmailAsync(to, subject, body);
        
        logger.LogInformation($"Handled {nameof(NotificationService)}");
    }

    public async Task SendSmsAsync(string phoneNumber, string message)
    {
        throw new NotImplementedException();
    }

    public async Task SendPushAsync(string deviceToken, string message)
    {
        throw new NotImplementedException();
    }

    public async Task AddNotificationAsync(Models.Notification notification, CancellationToken cancellationToken)
    {
        await context.Notifications.AddAsync(notification, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task UpdateNotificationAsync(Guid userId, CancellationToken cancellationToken)
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
    
    public async Task<Models.Notification?> GetNotificationAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await context.Notifications
            .FirstOrDefaultAsync(notification => 
                notification.UserId == userId,
                cancellationToken);
    }
}