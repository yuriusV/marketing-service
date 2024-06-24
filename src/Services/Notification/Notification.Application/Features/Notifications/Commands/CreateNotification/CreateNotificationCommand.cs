using Notification.Application.Features.Notifications.Queries.GetNotification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
    }
}
