using AutoMapper;
using Campaign.Application.Contracts.Persistence;
using MediatR;

namespace Campaign.Application.Features.Campaigns.Queries.GetCampaigns;

public class CampaignQueryHandler : IRequestHandler<CampaignQuery, IReadOnlyList<CampaignDto>>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IMapper _mapper;

    public CampaignQueryHandler(ICampaignRepository campaignRepository, IMapper mapper)
    {
        _campaignRepository = campaignRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CampaignDto>> Handle(CampaignQuery request, CancellationToken cancellationToken)
    {
        var campaign = await _campaignRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<CampaignDto>>(campaign)!;
    }
}
