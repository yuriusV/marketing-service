using AutoMapper;
using Campaign.Application.Contracts.Persistence;
using MediatR;

namespace Campaign.Application.Features.Templates.Queries.GetTemplates;

public class TemplateQueryHandler : IRequestHandler<TemplateQuery, IReadOnlyList<TemplateDto>>
{
    private readonly ITemplateRepository _templateRepository;
    private readonly IMapper _mapper;

    public TemplateQueryHandler(ITemplateRepository templateRepository, IMapper mapper)
    {
        _templateRepository = templateRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TemplateDto>> Handle(TemplateQuery request, CancellationToken cancellationToken)
    {
        var campaign = await _templateRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<TemplateDto>>(campaign)!;
    }
}
