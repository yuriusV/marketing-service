using AutoMapper;
using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using Campaign.Application.Features.Templates.Commands.DeleteTemplate;
using Campaign.Application.Features.Templates.Queries.GetTemplates;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Campaign.Application.Features.Templates.Commands.DeleteTemplate
{
    public class DeleteTemplateHandler : IRequestHandler<DeleteTemplateCommand, TemplateDto>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTemplateHandler> _logger;

        public DeleteTemplateHandler(ITemplateRepository templateRepository, IMapper mapper, ILogger<DeleteTemplateHandler> logger)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TemplateDto> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _templateRepository.GetByIdAsync(request.Id);

            if (campaign is null)
            {
                return new TemplateDto { Id = request.Id };
            }

            await _templateRepository.DeleteAsync(new Domain.Entities.Template(campaign.Id));
            return _mapper.Map<TemplateDto>(campaign)!;
        }
    }
}
