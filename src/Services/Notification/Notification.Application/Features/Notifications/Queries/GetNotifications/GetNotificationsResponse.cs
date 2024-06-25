namespace Notification.Application.Features.Notifications.Queries.GetNotifications;

public class GetNotificationsResponse
{
    public IReadOnlyList<NotificationDto> Notifications { get; set; }
}
