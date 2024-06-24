using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Commands.CreateCampaign;

public class CreateCampaignCommand : IRequest<CampaignDto>
{
    public string? Name { get; set; }

    public string? Query { get; set; }

    public string? Time { get; set; }

    public int? Priority { get; set; }

    public Guid? TemplateId { get; set; }
}
