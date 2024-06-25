using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;

public class DeleteCampaignCommand : IRequest<CampaignDto>
{
    public Guid Id { get; set; }
}
