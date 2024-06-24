using AutoMapper;
using Campaign.Application.Features.Campaigns.Commands.CreateCampaign;
using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using Campaign.Application.Features.Templates.Commands.CreateTemplate;
using Campaign.Application.Features.Templates.Queries.GetTemplates;

namespace Campaign.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCampaignCommand, Domain.Entities.Campaign>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Query, opt => opt.MapFrom(src => src.Query))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.TemplateId));
            CreateMap<Domain.Entities.Campaign, CampaignDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Query, opt => opt.MapFrom(src => src.Query))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.TemplateId));

            CreateMap<CreateTemplateCommand, Domain.Entities.Template>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));
            CreateMap<Domain.Entities.Template, TemplateDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));
        }
    }
}
