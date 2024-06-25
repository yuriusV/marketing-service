
using MediatR;
using Notification.Application.Features.Notifications.Queries.GetNotifications;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationCommand : NotificationDto, IRequest<CreateNotificationResponse>
{
}
