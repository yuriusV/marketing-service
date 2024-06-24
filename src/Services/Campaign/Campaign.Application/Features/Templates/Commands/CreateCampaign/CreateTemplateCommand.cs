using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using Campaign.Application.Features.Templates.Queries.GetTemplates;
using MediatR;

namespace Campaign.Application.Features.Templates.Commands.CreateTemplate
{
    public class CreateTemplateCommand : IRequest<TemplateDto>
    {
        public string Name { get; set; }
        public string Contents { get; set; }
    }
}
