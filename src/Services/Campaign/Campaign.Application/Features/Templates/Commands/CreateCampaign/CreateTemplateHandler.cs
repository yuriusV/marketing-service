﻿using AutoMapper;
using Campaign.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using Campaign.Application.Features.Templates.Queries.GetTemplates;

namespace Campaign.Application.Features.Templates.Commands.CreateTemplate;

public class CreateTemplateHandler : IRequestHandler<CreateTemplateCommand, TemplateDto>
{
    private readonly ITemplateRepository _templateRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateTemplateHandler> _logger;

    public CreateTemplateHandler(ITemplateRepository templateRepository, IMapper mapper, ILogger<CreateTemplateHandler> logger)
    {
        _templateRepository = templateRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<TemplateDto> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = _mapper.Map<Domain.Entities.Template>(request);
        var newTemplate = await _templateRepository.AddAsync(template!);
        return _mapper.Map<TemplateDto>(newTemplate)!;
    }
}
