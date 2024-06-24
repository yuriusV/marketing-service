using FluentValidation;

namespace Campaign.Application.Features.Templates.Commands.CreateTemplate;

public class CreateTemplateValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(256);
        RuleFor(x => x.Contents)
            .NotEmpty();
    }
}
