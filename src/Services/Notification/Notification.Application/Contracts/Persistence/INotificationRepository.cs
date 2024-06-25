namespace Notification.Application.Contracts.Persistence;

public interface INotificationRepository
{
    Task<string> CreateNotificationAsync(Domain.Entities.Notification notification);

    Task<IReadOnlyList<Domain.Entities.Notification>> GetNotificationsAsync();
}
