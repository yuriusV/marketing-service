using Notification.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationResponse>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateNotificationHandler> _logger;

    public CreateNotificationHandler(INotificationRepository NotificationRepository, IMapper mapper, ILogger<CreateNotificationHandler> logger)
    {
        _notificationRepository = NotificationRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateNotificationResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var NotificationEntity = _mapper.Map<Domain.Entities.Notification>(request);
        var newNotification = await _notificationRepository.CreateNotificationAsync(NotificationEntity!);
        return new CreateNotificationResponse { StreamItemId = newNotification };
    }
}
