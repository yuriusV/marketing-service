namespace Notification.Application.Features.Notifications.Queries.GetNotifications
{
    public class NotificationDto
    {
        public Guid TargetId { get; set; }

        public string Contents { get; set; }
    }
}
