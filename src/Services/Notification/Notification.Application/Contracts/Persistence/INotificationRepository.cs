using Notification.Application.Features.Notifications.Commands.CreateNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Contracts.Persistence
{
    public interface INotificationRepository
    {
        Task<string> CreateNotificationAsync(Domain.Entities.Notification notification);
    }
}
