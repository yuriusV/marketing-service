using Notification.Application.Contracts.Persistence;
using Notification.Application.Exceptions;
using Notification.Application.Features.Notifications.Commands.CreateNotification;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Queries.GetNotification
{
    public class NotificationQueryHandler : IRequestHandler<NotificationQuery, GetNotificationResponse>
    {
        private readonly INotificationRepository _NotificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationQueryHandler> _logger;

        public NotificationQueryHandler(INotificationRepository NotificationRepository, IMapper mapper, ILogger<NotificationQueryHandler> logger)
        {
            _NotificationRepository = NotificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetNotificationResponse> Handle(NotificationQuery request, CancellationToken cancellationToken)
        {
            var Notification = await _NotificationRepository.GetAsync(x => x.Id == request.NotificationId && x.CustomerId == request.CustomerId);

            if (Notification.CustomerId != request.NotificationId)
                throw new UnauthorizedAccessException();
            return _mapper.Map<GetNotificationResponse>(Notification)!;
        }
    }
}
