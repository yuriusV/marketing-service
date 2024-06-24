namespace Notification.Application.Contracts.Persistence;

public interface INotificationRepository
{
    Task<string> CreateNotificationAsync(Domain.Entities.Notification notification);
}
