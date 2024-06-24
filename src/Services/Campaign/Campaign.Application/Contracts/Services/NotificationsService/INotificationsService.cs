using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Contracts.Services.NotificationsService
{
    public interface INotificationsService
    {
        public Task<NotificationResponse> NotifyAsync(Notification notification);
    }
}
