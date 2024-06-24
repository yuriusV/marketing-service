using Notification.Application.Features.Notifications.Commands.CreateNotification;
using AutoMapper;

namespace Notification.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateNotificationCommand, Domain.Entities.Notification>()
            .ForMember(dest => dest.TargetId, opt => opt.MapFrom(src => src.TargetId))
            .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));
    }
}
