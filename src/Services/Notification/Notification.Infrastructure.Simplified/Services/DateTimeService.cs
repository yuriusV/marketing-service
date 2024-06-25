using Notification.Application.Contracts;

namespace Notification.Infrastructure.Simplified.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime DateTime => DateTime.UtcNow;
}
