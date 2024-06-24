using AutoMapper;
using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Features.Campaigns.Commands.CreateCampaign;
using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Features.Campaigns.Commands.CreateCampaign
{
    public class CreateCampaignHandler : IRequestHandler<CreateCampaignCommand, CampaignDto>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCampaignHandler> _logger;

        public CreateCampaignHandler(ICampaignRepository campaignRepository, IMapper mapper, ILogger<CreateCampaignHandler> logger)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CampaignDto> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaignEntity = _mapper.Map<Domain.Entities.Campaign>(request);
            var newCampaign = await _campaignRepository.AddAsync(campaignEntity!);
            return _mapper.Map<CampaignDto>(newCampaign)!;
        }
    }
}
