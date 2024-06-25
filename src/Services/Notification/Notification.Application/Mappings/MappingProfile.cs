using Notification.Application.Features.Notifications.Commands.CreateNotification;
using AutoMapper;
using Notification.Application.Features.Notifications.Queries.GetNotifications;

namespace Notification.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateNotificationCommand, Domain.Entities.Notification>()
            .ForMember(dest => dest.TargetId, opt => opt.MapFrom(src => src.TargetId))
            .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));

        CreateMap<Domain.Entities.Notification, NotificationDto>()
            .ForMember(dest => dest.TargetId, opt => opt.MapFrom(src => src.TargetId))
            .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));
    }
}
