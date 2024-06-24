using Notification.Application.Constants.Messages;
using Notification.Application.Features.Notifications.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Queries.GetNotification
{
    public class GetNotificationValidator : AbstractValidator<NotificationQuery>
    {
        public GetNotificationValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage(NotificationMessages.CustomerRequired);
            RuleFor(x => x.NotificationId)
                .NotEqual(Guid.Empty).WithMessage(NotificationMessages.NotificationRequired);
        }
    }
}
