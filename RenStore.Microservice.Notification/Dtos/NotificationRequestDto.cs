using RenStore.Microservice.Notification.Enums;

namespace RenStore.Microservice.Notification.Models;

public record NotificationRequestDto
(
    Guid UserId,
    NotificationType Type,
    string To,
    string Subject, 
    string Body
);