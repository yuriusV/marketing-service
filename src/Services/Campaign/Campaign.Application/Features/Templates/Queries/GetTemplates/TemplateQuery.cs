using Campaign.Application.Features.Templates.Queries.GetTemplates;
using MediatR;

namespace Campaign.Application.Features.Templates.Queries.GetTemplates
{
    public class TemplateQuery : IRequest<IReadOnlyList<TemplateDto>>
    {
    }
}
