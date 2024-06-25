using Notification.Application.Contracts;

namespace Notification.Infrastructure.Simplified.Services
{
    public class GuidProvider : IGuidProvider
    {
        public Guid Guid => Guid.NewGuid();
    }
}
