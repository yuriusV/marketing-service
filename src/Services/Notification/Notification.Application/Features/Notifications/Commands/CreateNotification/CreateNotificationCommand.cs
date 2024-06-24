
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<CreateNotificationResponse>
    {
        public Guid TargetId { get; set; }

        public string Contents { get; set; }
    }
}
