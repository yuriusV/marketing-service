using Campaign.Application.Features.Templates.Queries.GetTemplates;
using MediatR;

namespace Campaign.Application.Features.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommand : IRequest<TemplateDto>
{
    public Guid Id { get; set; }
}
