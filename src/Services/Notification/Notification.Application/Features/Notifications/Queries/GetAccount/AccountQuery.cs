using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Queries.GetNotification
{
    public class NotificationQuery : IRequest<GetNotificationResponse>
    {
        public Guid NotificationId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
