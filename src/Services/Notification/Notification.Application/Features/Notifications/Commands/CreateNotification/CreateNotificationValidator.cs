
using FluentValidation;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationValidator()
    {
        RuleFor(x => x.TargetId)
            .NotEqual(Guid.Empty);

        RuleFor(x => x.Contents)
            .NotEmpty();
    }
}
