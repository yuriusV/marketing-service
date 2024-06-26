﻿using AutoMapper;
using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Contracts.Services;
using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;

public class DeleteCampaignHandler : IRequestHandler<DeleteCampaignCommand, CampaignDto>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly ISchedulerService _schedulerService;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteCampaignHandler> _logger;

    public DeleteCampaignHandler(
        ICampaignRepository campaignRepository,
        ISchedulerService schedulerService, 
        IMapper mapper,
        ILogger<DeleteCampaignHandler> logger)
    {
        _campaignRepository = campaignRepository;
        _schedulerService = schedulerService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CampaignDto> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _campaignRepository.GetByIdAsync(request.Id);

        if (campaign is null)
        {
            return new CampaignDto { Id = request.Id };
        }

        await _campaignRepository.DeleteAsync(campaign);
        await _schedulerService.DeleteCampaignAsync(campaign.Id);
        return _mapper.Map<CampaignDto>(campaign)!;
    }
}
