using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Queries.GetNotification
{
    public class GetNotificationResponse
    {
        public Guid CustomerId { get; set; }
        public Guid NotificationId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
