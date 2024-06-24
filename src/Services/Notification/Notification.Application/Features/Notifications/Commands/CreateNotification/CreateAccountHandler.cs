using Notification.Application.Contracts.Persistence;
using Notification.Application.Features.Notifications.Queries.GetNotification;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly INotificationRepository _NotificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateNotificationHandler> _logger;

        public CreateNotificationHandler(INotificationRepository NotificationRepository, IMapper mapper, ILogger<CreateNotificationHandler> logger)
        {
            _NotificationRepository = NotificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var NotificationEntity = _mapper.Map<Domain.Entities.Notification>(request);
            var newNotification = await _NotificationRepository.AddAsync(NotificationEntity!);
            return newNotification.Id;
        }
    }
}
