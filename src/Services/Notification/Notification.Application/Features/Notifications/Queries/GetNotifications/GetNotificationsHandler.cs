using Notification.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Notification.Application.Features.Notifications.Queries.GetNotifications;

public class GetNotificationsHandler : IRequestHandler<GetNotificationsQuery, GetNotificationsResponse>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;

    public GetNotificationsHandler(INotificationRepository NotificationRepository, IMapper mapper)
    {
        _notificationRepository = NotificationRepository;
        _mapper = mapper;
    }

    public async Task<GetNotificationsResponse> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository.GetNotificationsAsync();
        return new GetNotificationsResponse
        {
            Notifications = notifications.Select(_mapper.Map<NotificationDto>).ToList(),
        };
    }
}
