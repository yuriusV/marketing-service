
using MediatR;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationCommand : IRequest<CreateNotificationResponse>
{
    public Guid TargetId { get; set; }

    public string Contents { get; set; }
}
