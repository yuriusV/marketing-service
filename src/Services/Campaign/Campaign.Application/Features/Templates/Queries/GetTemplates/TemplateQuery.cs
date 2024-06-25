using MediatR;

namespace Campaign.Application.Features.Templates.Queries.GetTemplates;

public class TemplateQuery : IRequest<IReadOnlyList<TemplateDto>>
{
}
