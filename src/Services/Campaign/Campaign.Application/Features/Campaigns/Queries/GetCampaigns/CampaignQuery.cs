using MediatR;

namespace Campaign.Application.Features.Campaigns.Queries.GetCampaigns
{
    public class CampaignQuery : IRequest<IReadOnlyList<CampaignDto>>
    {
    }
}
