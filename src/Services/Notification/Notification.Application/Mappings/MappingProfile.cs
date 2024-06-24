using Notification.Application.Features.Notifications.Commands.CreateNotification;
using Notification.Application.Features.Notifications.Queries.GetNotification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateNotificationCommand, Domain.Entities.Notification>()
                .ForMember(dest => dest.TargetId, opt => opt.MapFrom(src => src.TargetId))
                .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));
        }
    }
}
