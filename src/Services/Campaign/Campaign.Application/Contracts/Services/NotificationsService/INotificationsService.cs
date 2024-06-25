namespace Campaign.Application.Contracts.Services.NotificationsService;

public interface INotificationsService
{
    public Task<NotificationResponse> NotifyAsync(Notification notification);
}
