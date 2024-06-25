using FluentValidation;

namespace Campaign.Application.Features.Templates.Commands.DeleteTemplate;

public class DeleteTemplateValidator : AbstractValidator<DeleteTemplateCommand>
{
    public DeleteTemplateValidator()
    {
    }
}
