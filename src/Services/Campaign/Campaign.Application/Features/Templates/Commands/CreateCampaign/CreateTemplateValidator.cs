using FluentValidation;

namespace Campaign.Application.Features.Templates.Commands.CreateTemplate;

public class CreateTemplateValidator : AbstractValidator<CreateTemplateCommand>
{
    private const int MaxNameLength = 256;

    public CreateTemplateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(MaxNameLength);
        RuleFor(x => x.Contents)
            .NotEmpty();
    }
}
