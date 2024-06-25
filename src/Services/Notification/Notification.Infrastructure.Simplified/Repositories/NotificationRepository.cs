using Notification.Application.Contracts;
using Notification.Application.Contracts.Persistence;

namespace Notification.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly IGuidProvider _guidProvider;

    private LinkedList<Domain.Entities.Notification> _inMemoryStorage;

    public NotificationRepository(IGuidProvider guidProvider)
    {
        _guidProvider = guidProvider;
        _inMemoryStorage = new LinkedList<Domain.Entities.Notification>();
    }

    public async Task<string> CreateNotificationAsync(Domain.Entities.Notification notification)
    {
        _inMemoryStorage.AddLast(notification);

        return _guidProvider.Guid.ToString();
    }

    public async Task<IReadOnlyList<Domain.Entities.Notification>> GetNotificationsAsync()
    {
        return _inMemoryStorage.ToList();
    }
}
